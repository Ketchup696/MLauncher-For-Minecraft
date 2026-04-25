namespace MoonLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnPlay = new Button();
            LabelGameVersion = new Label();
            progressBar = new ProgressBar();
            NameLauncher = new Label();
            btnSettings = new Button();
            cmbVersion = new ComboBox();
            statusLabel = new Label();
            cmbNicknames = new ComboBox();
            btnDeleteVersion = new Button();
            btnGameDir = new Button();
            btnAccountManagement = new Button();
            labelSelectAccount = new Label();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(44, 219);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(400, 100);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // LabelGameVersion
            // 
            LabelGameVersion.AutoSize = true;
            LabelGameVersion.Location = new Point(109, 59);
            LabelGameVersion.Name = "LabelGameVersion";
            LabelGameVersion.Size = new Size(82, 15);
            LabelGameVersion.TabIndex = 1;
            LabelGameVersion.Text = "Game Version:";
            LabelGameVersion.Click += btnPlay_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(69, 190);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(350, 23);
            progressBar.TabIndex = 4;
            progressBar.Visible = false;
            // 
            // NameLauncher
            // 
            NameLauncher.AutoSize = true;
            NameLauncher.Font = new Font("Segoe UI", 11F);
            NameLauncher.Location = new Point(140, 9);
            NameLauncher.Name = "NameLauncher";
            NameLauncher.Size = new Size(178, 20);
            NameLauncher.TabIndex = 5;
            NameLauncher.Text = "Minecraft Moon Launcher";
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Image = Properties.Resources.IconSettingsMoonLauncher_32x32;
            btnSettings.Location = new Point(450, 276);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(32, 32);
            btnSettings.TabIndex = 6;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // cmbVersion
            // 
            cmbVersion.FormattingEnabled = true;
            cmbVersion.Location = new Point(197, 55);
            cmbVersion.Name = "cmbVersion";
            cmbVersion.Size = new Size(100, 23);
            cmbVersion.TabIndex = 8;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(69, 172);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(28, 15);
            statusLabel.TabIndex = 9;
            statusLabel.Text = "File:";
            statusLabel.Visible = false;
            // 
            // cmbNicknames
            // 
            cmbNicknames.FormattingEnabled = true;
            cmbNicknames.Location = new Point(197, 95);
            cmbNicknames.Name = "cmbNicknames";
            cmbNicknames.Size = new Size(100, 23);
            cmbNicknames.TabIndex = 10;
            // 
            // btnDeleteVersion
            // 
            btnDeleteVersion.Location = new Point(309, 55);
            btnDeleteVersion.Name = "btnDeleteVersion";
            btnDeleteVersion.Size = new Size(50, 23);
            btnDeleteVersion.TabIndex = 13;
            btnDeleteVersion.Text = "Delete";
            btnDeleteVersion.UseVisualStyleBackColor = true;
            btnDeleteVersion.Click += btnDeleteVersion_Click;
            // 
            // btnGameDir
            // 
            btnGameDir.FlatAppearance.BorderSize = 0;
            btnGameDir.FlatStyle = FlatStyle.Flat;
            btnGameDir.Image = Properties.Resources.Folder;
            btnGameDir.Location = new Point(450, 229);
            btnGameDir.Name = "btnGameDir";
            btnGameDir.Size = new Size(32, 32);
            btnGameDir.TabIndex = 14;
            btnGameDir.UseVisualStyleBackColor = true;
            btnGameDir.Click += btnGameDir_Click;
            // 
            // btnAccountManagement
            // 
            btnAccountManagement.Location = new Point(170, 139);
            btnAccountManagement.Name = "btnAccountManagement";
            btnAccountManagement.Size = new Size(148, 23);
            btnAccountManagement.TabIndex = 15;
            btnAccountManagement.Text = "Account Management";
            btnAccountManagement.UseVisualStyleBackColor = true;
            btnAccountManagement.Click += btnAccountManagement_Click;
            // 
            // labelSelectAccount
            // 
            labelSelectAccount.AutoSize = true;
            labelSelectAccount.Location = new Point(104, 98);
            labelSelectAccount.Name = "labelSelectAccount";
            labelSelectAccount.Size = new Size(87, 15);
            labelSelectAccount.TabIndex = 16;
            labelSelectAccount.Text = "Select account:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(495, 334);
            Controls.Add(labelSelectAccount);
            Controls.Add(btnAccountManagement);
            Controls.Add(btnGameDir);
            Controls.Add(btnDeleteVersion);
            Controls.Add(cmbNicknames);
            Controls.Add(statusLabel);
            Controls.Add(cmbVersion);
            Controls.Add(btnSettings);
            Controls.Add(NameLauncher);
            Controls.Add(progressBar);
            Controls.Add(LabelGameVersion);
            Controls.Add(btnPlay);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "MoonLauncher";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private Label LabelGameVersion;
        private ProgressBar progressBar;
        private Label NameLauncher;
        private Button btnSettings;
        private ComboBox cmbVersion;
        private Label statusLabel;
        private ComboBox cmbNicknames;
        private Button btnDeleteVersion;
        private Button btnGameDir;
        private Button btnAccountManagement;
        private Label labelSelectAccount;
    }
}
