using AutoUpdaterDotNET;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using CmlLib.Core.Version;
using CmlLib.Core.VersionMetadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MoonLauncher
{
    public partial class Form1 : Form
    {
        private string defaultNickname = "Player";
        private LauncherSettings _settings;
        private readonly string _settingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MoonLauncher");
        private readonly string _settingsFile;

        private MinecraftLauncher _launcher;

        private string gameDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");

        public Form1()
        {
            InitializeComponent();
            btnPlay.Enabled = false;

            if (!Directory.Exists(_settingsFolder))
            {
                Directory.CreateDirectory(_settingsFolder);
            }
            _settingsFile = Path.Combine(_settingsFolder, "settings.json");

            LoadSettings();

            InitializeLauncher();
        }

        private void InitializeLauncher()
        {
            var path = new MinecraftPath(gameDir);
            _launcher = new MinecraftLauncher(path);

            _launcher.FileProgressChanged += _launcher_FileProgressChanged;
        }

        private void _launcher_FileProgressChanged(object? sender, CmlLib.Core.Installers.InstallerProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => _launcher_FileProgressChanged(sender, e)));
                return;
            }

            progressBar.Maximum = e.TotalTasks;
            progressBar.Value = e.ProgressedTasks;
            statusLabel.Text = $"File: {e.Name}";
        }

        private void LoadSettings()
        {

            if (File.Exists(_settingsFile))
            {
                string json = File.ReadAllText(_settingsFile);
                _settings = JsonConvert.DeserializeObject<LauncherSettings>(json);
                if (_settings == null)
                {
                    _settings = new LauncherSettings();
                }
            }
            else
            {
                _settings = new LauncherSettings();
            }

            if (_settings.SavedNicknames == null)
            {
                _settings.SavedNicknames = new List<string>();
                _settings.SavedNicknames.Add(defaultNickname);
                SaveSettings();
            }
            else if (_settings.SavedNicknames.Count == 0)
            {
                _settings.SavedNicknames.Add(defaultNickname);
                SaveSettings();
            }

            cmbNicknames.DataSource = _settings.SavedNicknames;
            cmbNicknames.SelectedItem = _settings.LastNickname;
        }

        private void SaveSettings()
        {
            if (!Directory.Exists(_settingsFolder))
            {
                Directory.CreateDirectory(_settingsFolder);
            }
            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(_settingsFile, json);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/Ketchup696/MLauncher-For-Minecraft/refs/heads/master/update.xml");

            var launcher = _launcher;
            var allVersions = await launcher.GetAllVersionsAsync();
            var releaseVersions = allVersions
                .Where(v => v.Type == "release")
                .Select(v => v.Name)
                .ToList();
            cmbVersion.DataSource = releaseVersions;

            if (!string.IsNullOrEmpty(_settings.LastVersion) && releaseVersions.Contains(_settings.LastVersion))
            {
                cmbVersion.SelectedItem = _settings.LastVersion;
            }
            else
            {
                if (releaseVersions.Count > 0)
                {
                    cmbVersion.SelectedIndex = 0;
                }
            }

            btnPlay.Enabled = true;
        }

        private void GameVersion_Click(object sender, EventArgs e)
        {

        }

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            progressBar.Visible = true;
            statusLabel.Visible = true;

            _settings.LastNickname = cmbNicknames.Text;
            SaveSettings();

            try
            {
                await LaunchMinecraftAsync(cmbNicknames.Text);
            }
            catch (Exception ex)
            {
                string errorText = ex.ToString();
                if (errorText.Contains("Java", StringComparison.OrdinalIgnoreCase) || errorText.Contains("runtime", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Error java. Press Start again.", "Error java", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnPlay.Enabled = true;
                progressBar.Visible = false;
                statusLabel.Visible = false;
            }
        }

        private async Task LaunchMinecraftAsync(string nickname)
        {
            string version = cmbVersion.SelectedItem?.ToString() ?? _settings.LastVersion;

            _settings.LastVersion = version;
            SaveSettings();

            await _launcher.InstallAsync(version);

            var launchOption = new MLaunchOption
            {
                Session = MSession.CreateOfflineSession(nickname),
                MaximumRamMb = _settings.AllocatedMemoryGB * 1024,
                JavaPath = null
            };

            var process = await _launcher.InstallAndBuildProcessAsync(version, launchOption);

            process.Start();
            this.Hide();
            await process.WaitForExitAsync();
            this.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm(_settings))
            {
                if (settingsForm.ShowDialog(this) == DialogResult.OK)
                {
                    _settings = settingsForm.Settings;
                    SaveSettings();
                }
            }
        }

        private void btnSaveNickname_Click(object sender, EventArgs e)
        {
            string txtNickname = txtNewNickname.Text;

            if (string.IsNullOrWhiteSpace(txtNickname))
            {
                cmbNicknames.SelectedItem = defaultNickname;
            }
            else
            {
                if (txtNickname != null && !_settings.SavedNicknames.Contains(txtNickname))
                {
                    _settings.SavedNicknames.Add(txtNickname);
                }
            }
            SaveSettings();
            cmbNicknames.DataSource = null;
            cmbNicknames.DataSource = _settings.SavedNicknames;
        }

        private void btnGameDir_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(gameDir))
            {
                MessageBox.Show($"Directory not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Process.Start("explorer.exe", gameDir);
            }
        }

        private void btnDeleteNickname_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteNickname = MessageBox.Show($"Are you sure you want to delete this account?", "Deleting a account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteNickname == DialogResult.Yes)
            {
                string selectNickname = cmbNicknames.Text;
                if (_settings.SavedNicknames.Contains(selectNickname))
                {
                    _settings.SavedNicknames.Remove(selectNickname);

                    if (_settings.SavedNicknames.Count == 0)
                    {
                        _settings.SavedNicknames.Add(defaultNickname);
                    }

                    SaveSettings();
                    cmbNicknames.DataSource = null;
                    cmbNicknames.DataSource = _settings.SavedNicknames;
                }
            }
        }

        private void btnDeleteVersion_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteVersion = MessageBox.Show($"Are you sure you want to delete this version?", "Deleting a version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteVersion == DialogResult.Yes)
            {
                string folderVersions = Path.Combine(gameDir, "versions");
                string deleteVersion = cmbVersion.Text;
                string folderDeleteVersion = Path.Combine(folderVersions, deleteVersion);
                try
                {
                    Directory.Delete(folderDeleteVersion, recursive: true);
                    MessageBox.Show($"This version has been successfully deleted", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show($"Folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show($"Not enough rights.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}