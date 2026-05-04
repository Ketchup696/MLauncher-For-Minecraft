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
        
        private List<string> allAccounts = new();
        private List<string> newSavedAccounts = new();
        private List<string> newDeleteAccounts = new();

        private string defaultNickname = "Player";
        public AccountManagment(LauncherSettings settings)
        {
            InitializeComponent();
            Settings = settings ?? new LauncherSettings();

            foreach (var item in Settings.SavedNicknames)
            {
                allAccounts.Add(item);
            }
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            cmbNicknames.DataSource = allAccounts;
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
                if (txtNickname is not null && !allAccounts.Contains(txtNickname) && !newSavedAccounts.Contains(txtNickname))
                {
                    newSavedAccounts.Add(txtNickname);
                    allAccounts.Add(txtNickname);
                }
            }
            cmbNicknames.DataSource = null;
            cmbNicknames.DataSource = allAccounts;
        }

        private void btnDeleteNickname_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteNickname = MessageBox.Show($"Are you sure you want to delete this account?", "Deleting a account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteNickname == DialogResult.Yes)
            {
                string selectNickname = cmbNicknames.Text;
                if (allAccounts.Contains(selectNickname))
                {
                    allAccounts.Remove(selectNickname);
                    newDeleteAccounts.Add(selectNickname);

                    if (allAccounts.Count == 0)
                    {
                        allAccounts.Add(defaultNickname);
                        if (!newSavedAccounts.Contains(defaultNickname))
                            newSavedAccounts.Add(defaultNickname);
                    }
                    cmbNicknames.DataSource = null;
                    cmbNicknames.DataSource = allAccounts;
                    cmbNicknames.Text = allAccounts.FirstOrDefault();
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (Settings == null)
                Settings = new LauncherSettings();

            foreach (var account in newSavedAccounts)
            {
                if (!Settings.SavedNicknames.Contains(account))
                    Settings.SavedNicknames.Add(account);
            }

            foreach (var account in newDeleteAccounts)
            {
                if (Settings.SavedNicknames.Contains(account))
                    Settings.SavedNicknames.Remove(account);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
