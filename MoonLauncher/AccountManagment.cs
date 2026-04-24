using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Windows.Forms;
using static MoonLauncher.StaticRequests;

namespace MoonLauncher
{
    public partial class AccountManagment : Form
    {
        public LauncherSettings Settings { get; private set; }

        private int SettingsChangesCount = 0;

        public AccountManagment(LauncherSettings settings)
        {
            InitializeComponent();
            Settings = settings ?? new LauncherSettings();
        }

        private List<string> SaveNicknameStorage = new List<string> {};
        private List<string> DeleteNicknameStorage = new List<string> {};

        private void SaveChanges()
        {
            if (DeleteNicknameStorage.Count > 0)
            {
                foreach (string nick in DeleteNicknameStorage)
                {
                    Settings.SavedNicknames.Remove(nick);
                }
            }

            if (SaveNicknameStorage.Count > 0)
            {
                foreach (string nick in SaveNicknameStorage)
                {
                    Settings.SavedNicknames.Add(nick);
                }
            }

            cmbNicknames.DataSource = Settings.SavedNicknames;
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            cmbNicknames.DataSource = Settings.SavedNicknames;
        }

        private void btnSaveNickname_Click(object sender, EventArgs e)
        {
            string txtNickname = txtNewNickname.Text;

            if (string.IsNullOrWhiteSpace(txtNickname))
            {
                MessageBox.Show("The nickname field must not be empty!");
                return;
            }

            txtNickname = txtNickname.Trim();

            if (!Settings.SavedNicknames.Contains(txtNickname))
            {
                SaveNicknameStorage.Add(txtNickname);
                SettingsChangesCount++;
            }
            else
            {
                MessageBox.Show("This nickname already exists!");
                return;
            }
        }

        private void btnDeleteNickname_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteNickname = MessageBox.Show($"Are you sure you want to delete this account?", "Deleting a account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteNickname == DialogResult.Yes)
            {
                string selectedNickname = cmbNicknames.Text;

                if (selectedNickname == defaultNickname)
                {
                    MessageBox.Show("You cannot delete the standard user!");
                }
                else
                {
                    if (Settings.SavedNicknames.Contains(selectedNickname))
                    {
                        DeleteNicknameStorage.Add(selectedNickname);
                        SettingsChangesCount++;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Settings is null)
                Settings = new LauncherSettings();

            DialogResult = DialogResult.OK;
            //Close();  Unnecessary?
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //Close();  Unnecessary?
        }

        private void accmanagement_Close(object sender, FormClosingEventArgs e)
        {
            if (SettingsChangesCount == 0)
                return;

            DialogResult saveChanges = MessageBox.Show($"Save {SettingsChangesCount} changes?", "Saving changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (saveChanges == DialogResult.Yes)
            {
                SaveChanges();
                SettingsChangesCount = 0;
                DialogResult = DialogResult.OK;
            }
            else
            {
                SettingsChangesCount = 0;
            }
        }
    }
}
