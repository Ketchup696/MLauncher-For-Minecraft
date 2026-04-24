using AutoUpdaterDotNET;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using CmlLib.Core.Version;
using CmlLib.Core.VersionMetadata;
using Microsoft.VisualBasic;
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
using System.Net.NetworkInformation;
using static MoonLauncher.StaticRequests;

namespace MoonLauncher
{
    public partial class Form1 : Form
    {
        private LauncherSettings _settings;
        private readonly string _settingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MoonLauncher");
        private readonly string _settingsFile;

        private MinecraftLauncher _launcher;

        private string defaultGameDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");

        public Form1()
        {
            InitializeComponent();
            btnPlay.Enabled = false;

            if (!Directory.Exists(_settingsFolder))
                Directory.CreateDirectory(_settingsFolder);

            _settingsFile = Path.Combine(_settingsFolder, "settings.json");

            LoadSettings();

            InitializeLauncher();
        }

        private void InitializeLauncher()
        {
            var path = new MinecraftPath(_settings.GameDir);
            _launcher = new MinecraftLauncher(path);

            _launcher.FileProgressChanged += _launcher_FileProgressChanged;
        }

        private void _launcher_FileProgressChanged(object? sender, CmlLib.Core.Installers.InstallerProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => _launcher_FileProgressChanged(sender, e)));
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
                if (_settings is null)
                    _settings = new LauncherSettings();
            }
            else
            {
                _settings = new LauncherSettings();
            }

            if (_settings.SavedNicknames is null || _settings.SavedNicknames.Count is 0)
            {
                _settings.SavedNicknames = [defaultNickname]; // use array instead of List
                SaveSettings();
            }

            if (string.IsNullOrEmpty(_settings.GameDir))
            {
                _settings.GameDir = defaultGameDir;
                SaveSettings();
            }

            cmbNicknames.DataSource = _settings.SavedNicknames;
            cmbNicknames.Text = _settings.LastNickname;
        }

        private void SaveSettings()
        {
            if (!Directory.Exists(_settingsFolder))
                Directory.CreateDirectory(_settingsFolder);

            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(_settingsFile, json);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/Ketchup696/MLauncher-For-Minecraft/refs/heads/master/update.xml");

            LoadVersionListAsync();
        }

        private async void LoadVersionListAsync()
        {
            try
            {
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
                        cmbVersion.SelectedIndex = 0;
                }
            }
            catch
            {
                MessageBox.Show($"Failed to retrieve versions. Please check your internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPlay.Enabled = true;
            }
        }

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            progressBar.Visible = true;
            statusLabel.Visible = true;

            _settings.LastNickname = cmbNicknames.Text;
            SaveSettings();

            if (_settings.GameDir != _settings.LastGameDir)
            {
                await CopyDirectoryAsync(_settings.LastGameDir, _settings.GameDir);
                _settings.LastGameDir = _settings.GameDir;
                SaveSettings();
                InitializeLauncher();
            }

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
            Hide();
            await process.WaitForExitAsync();
            Show();
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

        private void btnAccountManagement_Click(object sender, EventArgs e)
        {
            using (var accountManagment = new AccountManagment(_settings))
            {
                if(accountManagment.ShowDialog(this) == DialogResult.OK)
                {
                    _settings = accountManagment.Settings;
                    SaveSettings();
                    string nullNickname = cmbNicknames.Text;
                    if (string.IsNullOrEmpty(nullNickname))
                        cmbNicknames.Text = _settings.SavedNicknames.FirstOrDefault() ?? defaultNickname;

                    //cmbNicknames.DataSource = null;
                    cmbNicknames.DataSource = _settings.SavedNicknames.ToList();
                    cmbNicknames.Text = _settings.SavedNicknames.FirstOrDefault() ?? defaultNickname;
                }
            }
        }

        private void btnGameDir_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_settings.GameDir))
            {
                MessageBox.Show($"Directory not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Process.Start("explorer.exe", _settings.GameDir);
            }
        }

        private void btnDeleteVersion_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteVersion = MessageBox.Show($"Are you sure you want to delete this version?", "Deleting a version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteVersion == DialogResult.Yes)
            {
                string folderVersions = Path.Combine(_settings.GameDir, "versions");
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

        public async Task CopyDirectoryAsync(string sourceDir, string destDir, bool overwrite = true)
        {
            if (!Directory.Exists(sourceDir)) return;

            Directory.CreateDirectory(destDir);

            int totalFiles = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories).Length;
            int copiedFiles = 0;

            await Task.Run(() =>
            {
                CopyRecursive(sourceDir, destDir, overwrite, totalFiles, ref copiedFiles);
            });
        }

        private void CopyRecursive(string source, string dest, bool overwrite, int totalFiles, ref int copiedFiles)
        {
            foreach (string file in Directory.GetFiles(source))
            {
                string destFile = Path.Combine(dest, Path.GetFileName(file));
                File.Copy(file, destFile, overwrite);

                copiedFiles++;
            }

            foreach (string dir in Directory.GetDirectories(source))
            {
                string destDir = Path.Combine(dest, Path.GetFileName(dir));
                Directory.CreateDirectory(destDir);
                CopyRecursive(dir, destDir, overwrite, totalFiles, ref copiedFiles);
            }
        }
    }
}