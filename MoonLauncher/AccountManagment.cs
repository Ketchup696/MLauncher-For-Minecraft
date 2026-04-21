using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Windows.Forms;

namespace MoonLauncher
{
    public partial class AccountManagment : Form
    {
        public LauncherSettings Settings { get; private set; }

        private string defaultNickname = "Player";
        public AccountManagment(LauncherSettings settings)
        {
            InitializeComponent();
            Settings = settings ?? new LauncherSettings();
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
                cmbNicknames.SelectedItem = defaultNickname;
            }
            else
            {
                if (txtNickname != null && !Settings.SavedNicknames.Contains(txtNickname))
                {
                    Settings.SavedNicknames.Add(txtNickname);
                }
            }
            cmbNicknames.DataSource = null;
            cmbNicknames.DataSource = Settings.SavedNicknames;
        }

        private void btnDeleteNickname_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteNickname = MessageBox.Show($"Are you sure you want to delete this account?", "Deleting a account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteNickname == DialogResult.Yes)
            {
                string selectNickname = cmbNicknames.Text;
                if (Settings.SavedNicknames.Contains(selectNickname))
                {
                    Settings.SavedNicknames.Remove(selectNickname);

                    if (Settings.SavedNicknames.Count == 0)
                    {
                        Settings.SavedNicknames.Add(defaultNickname);
                    }
                    cmbNicknames.DataSource = null;
                    cmbNicknames.DataSource = Settings.SavedNicknames;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Settings == null)
            {
                Settings = new LauncherSettings();
            }

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
