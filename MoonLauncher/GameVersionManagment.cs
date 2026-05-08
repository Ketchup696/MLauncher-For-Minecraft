using CmlLib.Core;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.System;

namespace MoonLauncher
{
    public partial class GameVersionManagment : Form
    {
        private List<string> AllVerions = new();
        private List<string> ReleaseVerions = new();
        private List<string> SnapshotVerions = new();
        private List<string> OptifineVerions = new();

        private MinecraftLauncher _launcher;
        public LauncherSettings Settings { get; private set; }

        private bool _lastChkSnapshot = false;
        private bool _lastChkOptifine = false;

        public GameVersionManagment(LauncherSettings settings)
        {
            InitializeComponent();
            Settings = settings ?? new LauncherSettings();
            InitializeLauncher();
            LoadVersionsListsAsync();
        }

        private void InitializeLauncher()
        {
            var path = new MinecraftPath(Settings.GameDir);
            _launcher = new MinecraftLauncher(path);
        }

        private void GameVersionManagment_Load(object sender, EventArgs e)
        {

        }

        private async void LoadVersionsListsAsync()
        {
            try
            {
                var launcher = _launcher;
                var allVersions = await launcher.GetAllVersionsAsync();
                var releaseVersions = allVersions
                    .Where(v => v.Type == "release")
                    .Select(v => v.Name)
                    .ToList();
                ReleaseVerions = releaseVersions;
                foreach (var version in releaseVersions)
                {
                    AllVerions.Add(version);
                }

                var snapshotVersions = allVersions
                    .Where(v => v.Type == "snapshot")
                    .Select(v => v.Name)
                    .ToList();
                SnapshotVerions = snapshotVersions;
            }
            catch
            {
                MessageBox.Show($"Failed to retrieve versions. Please check your internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmbSelectVersionForInstall.DataSource = AllVerions;
            }
        }

        private async void UpdateVersionListAsync()
        {
            switch (chkSnapshot.Checked, chkOptifine.Checked)
            {
                case (true, true):

                    if(chkSnapshot.Checked != _lastChkSnapshot)
                    {

                    }

                    if (chkOptifine.Checked != _lastChkOptifine)
                    {

                    }

                    cmbSelectVersionForInstall.DataSource = null;
                    cmbSelectVersionForInstall.DataSource = AllVerions;
                    break;
                case (true, false):

                    if (chkSnapshot.Checked != _lastChkSnapshot)
                    {
                        foreach (var version in SnapshotVerions)
                        {
                            AllVerions.Add(version);
                        }
                    }

                    if (chkOptifine.Checked != _lastChkOptifine)
                    {

                    }

                    AllVerions.Sort();
                    AllVerions.Reverse();
                    _lastChkSnapshot = true;
                    cmbSelectVersionForInstall.DataSource = null;
                    cmbSelectVersionForInstall.DataSource = AllVerions;
                    break;
                case (false, true):

                    if (chkSnapshot.Checked != _lastChkSnapshot)
                    {

                    }

                    if (chkOptifine.Checked != _lastChkOptifine)
                    {

                    }

                    cmbSelectVersionForInstall.DataSource = null;
                    cmbSelectVersionForInstall.DataSource = AllVerions;
                    break;
                case (false, false):

                    if (chkSnapshot.Checked != _lastChkSnapshot)
                    {
                        foreach (var version in SnapshotVerions)
                        {
                            AllVerions.Remove(version);
                        }
                    }

                    if (chkOptifine.Checked != _lastChkOptifine)
                    {

                    }

                    AllVerions.Sort();
                    AllVerions.Reverse();
                    _lastChkSnapshot = false;
                    cmbSelectVersionForInstall.DataSource = null;
                    cmbSelectVersionForInstall.DataSource = AllVerions;
                    break;
            }
        }

        private void chkSnapshot_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVersionListAsync();
        }

        private void chkOptifine_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVersionListAsync();
        }
    }
}
