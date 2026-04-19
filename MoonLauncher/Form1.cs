using AutoUpdaterDotNET;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using CmlLib.Core.Version;
using CmlLib.Core.VersionMetadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MoonLauncher
{
    public partial class Form1 : Form
    {

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

            if (!string.IsNullOrEmpty(_settings.LastNickname))
            {
                txtNickname.Text = _settings.LastNickname;
            }
            else
            {
                txtNickname.Text = "Player";
            }   
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
            AutoUpdater.Start("https://raw.githubusercontent.com/Ketchup696/MLauncher-For-Minecraft/refs/heads/master/MoonLauncher/update.xml");

            var launcher = _launcher;
            var allVersions = await launcher.GetAllVersionsAsync();
            var releaseVersions = allVersions
                .Where(v => v.Type == "release")
                .Select(v => v.Name)
                .ToList();
            cmbVersion.DataSource = releaseVersions;

            if(!string.IsNullOrEmpty(_settings.LastVersion) && releaseVersions.Contains(_settings.LastVersion))
            {
                cmbVersion.SelectedItem = _settings.LastVersion;
            }
            else
            {
                if(releaseVersions.Count > 0)
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

            try
            {
                await LaunchMinecraftAsync(txtNickname.Text);
            }
            catch (Exception ex)
            {
                string errorText = ex.ToString();
                if(errorText.Contains("Java", StringComparison.OrdinalIgnoreCase) || errorText.Contains("runtime", StringComparison.OrdinalIgnoreCase))
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
            string nickname = txtNickname.Text.Trim();

            if (string.IsNullOrEmpty(nickname))
            {
                nickname = "Player";
            }

            _settings.LastNickname = nickname;
            SaveSettings();
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               