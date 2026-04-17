using System;
using System.Windows.Forms;

namespace MoonLauncher
{
    public partial class SettingsForm : Form
    {
        public LauncherSettings Settings { get; private set; }
            
        public SettingsForm(LauncherSettings settings)
        {
            InitializeComponent();
            Settings = settings ?? new LauncherSettings();
            LoadSettingsToUI();
        }
        private void LoadSettingsToUI()
        {
            numMemory.Value = Settings.AllocatedMemoryGB;
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if(Settings != null)
            {
                numMemory.Value = Settings.AllocatedMemoryGB;
            }
            else
            {
                numMemory.Value = 4;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Settings == null)
            {
                Settings = new LauncherSettings();
            }

            Settings.AllocatedMemoryGB = (int)numMemory.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
