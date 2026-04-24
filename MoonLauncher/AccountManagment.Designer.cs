namespace MoonLauncher
{
    partial class AccountManagment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManagment));
            btnSaveAccount = new Button();
            btnDeleteAccount = new Button();
            cmbNicknames = new ComboBox();
            txtNewNickname = new TextBox();
            labelAccountManagment = new Label();
            labelDelete = new Label();
            labelCreate = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnSaveAccount
            // 
            btnSaveAccount.Location = new Point(164, 60);
            btnSaveAccount.Name = "btnSaveAccount";
            btnSaveAccount.Size = new Size(49, 23);
            btnSaveAccount.TabIndex = 0;
            btnSaveAccount.Text = "Save";
            btnSaveAccount.UseVisualStyleBackColor = true;
            btnSaveAccount.Click += btnSaveNickname_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Location = new Point(163, 112);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(50, 23);
            btnDeleteAccount.TabIndex = 1;
            btnDeleteAccount.Text = "Delete";
            btnDeleteAccount.UseVisualStyleBackColor = true;
            btnDeleteAccount.Click += btnDeleteNickname_Click;
            // 
            // cmbNicknames
            // 
            cmbNicknames.FormattingEnabled = true;
            cmbNicknames.Location = new Point(19, 112);
            cmbNicknames.Name = "cmbNicknames";
            cmbNicknames.Size = new Size(121, 23);
            cmbNicknames.TabIndex = 2;
            // 
            // txtNewNickname
            // 
            txtNewNickname.Location = new Point(19, 60);
            txtNewNickname.Name = "txtNewNickname";
            txtNewNickname.Size = new Size(121, 23);
            txtNewNickname.TabIndex = 3;
            // 
            // labelAccountManagment
            // 
            labelAccountManagment.AutoSize = true;
            labelAccountManagment.Font = new Font("Segoe UI", 11F);
            labelAccountManagment.Location = new Point(41, 9);
            labelAccountManagment.Name = "labelAccountManagment";
            labelAccountManagment.Size = new Size(147, 20);
            labelAccountManagment.TabIndex = 4;
            labelAccountManagment.Text = "Account managment";
            labelAccountManagment.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelDelete
            // 
            labelDelete.AutoSize = true;
            labelDelete.Location = new Point(56, 94);
            labelDelete.Name = "labelDelete";
            labelDelete.Size = new Size(43, 15);
            labelDelete.TabIndex = 5;
            labelDelete.Text = "Delete:";
            // 
            // labelCreate
            // 
            labelCreate.AutoSize = true;
            labelCreate.Location = new Point(56, 42);
            labelCreate.Name = "labelCreate";
            labelCreate.Size = new Size(44, 15);
            labelCreate.TabIndex = 6;
            labelCreate.Text = "Create:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(19, 161);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(138, 161);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AccountManagment
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(230, 204);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(labelCreate);
            Controls.Add(labelDelete);
            Controls.Add(labelAccountManagment);
            Controls.Add(txtNewNickname);
            Controls.Add(cmbNicknames);
            Controls.Add(btnDeleteAccount);
            Controls.Add(btnSaveAccount);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AccountManagment";
            Text = "Account Managment";
            FormClosing += accmanagement_Close;
            Load += CreateAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSaveAccount;
        private Button btnDeleteAccount;
        private ComboBox cmbNicknames;
        private TextBox txtNewNickname;
        private Label labelAccountManagment;
        private Label labelDelete;
        private Label labelCreate;
        private Button btnSave;
        private Button btnCancel;
    }
}