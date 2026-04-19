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
            btnPlay = new Button();
            LabelGameVersion = new Label();
            Nickname = new Label();
            txtNickname = new TextBox();
            progressBar = new ProgressBar();
            NameLauncher = new Label();
            btnSettings = new Button();
            btnSaveNickname = new Button();
            cmbVersion = new ComboBox();
            statusLabel = new Label();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(37, 174);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(237, 96);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // LabelGameVersion
            // 
            LabelGameVersion.AutoSize = true;
            LabelGameVersion.Location = new Point(26, 53);
            LabelGameVersion.Name = "LabelGameVersion";
            LabelGameVersion.Size = new Size(82, 15);
            LabelGameVersion.TabIndex = 1;
            LabelGameVersion.Text = "Game Version:";
            LabelGameVersion.Click += btnPlay_Click;
            // 
            // Nickname
            // 
            Nickname.AutoSize = true;
            Nickname.Location = new Point(44, 90);
            Nickname.Name = "Nickname";
            Nickname.Size = new Size(64, 15);
            Nickname.TabIndex = 2;
            Nickname.Text = "Nickname:";
            // 
            // txtNickname
            // 
            txtNickname.Location = new Point(111, 87);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(100, 23);
            txtNickname.TabIndex = 3;
            txtNickname.Text = "Player";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(72, 140);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(170, 23);
            progressBar.TabIndex = 4;
            progressBar.Visible = false;
            // 
            // NameLauncher
            // 
            NameLauncher.AutoSize = true;
            NameLauncher.Location = new Point(83, 21);
            NameLauncher.Name = "NameLauncher";
            NameLauncher.Size = new Size(145, 15);
            NameLauncher.TabIndex = 5;
            NameLauncher.Text = "Minecraft Moon Launcher";
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Image = Properties.Resources.IconSettingsMoonLauncher_32x32;
            btnSettings.Location = new Point(273, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(32, 32);
            btnSettings.TabIndex = 6;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSaveNickname
            // 
            btnSaveNickname.Location = new Point(223, 87);
            btnSaveNickname.Name = "btnSaveNickname";
            btnSaveNickname.Size = new Size(51, 23);
            btnSaveNickname.TabIndex = 7;
            btnSaveNickname.Text = "Save";
            btnSaveNickname.UseVisualStyleBackColor = true;
            btnSaveNickname.Click += btnSaveNickname_Click;
            // 
            // cmbVersion
            // 
            cmbVersion.FormattingEnabled = true;
            cmbVersion.Location = new Point(111, 50);
            cmbVersion.Name = "cmbVersion";
            cmbVersion.Size = new Size(100, 23);
            cmbVersion.TabIndex = 8;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 123);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(38, 15);
            statusLabel.TabIndex = 9;
            statusLabel.Text = "label1";
            statusLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 282);
            Controls.Add(statusLabel);
            Controls.Add(cmbVersion);
            Controls.Add(btnSaveNickname);
            Controls.Add(btnSettings);
            Controls.Add(NameLauncher);
            Controls.Add(progressBar);
            Controls.Add(txtNickname);
            Controls.Add(Nickname);
            Controls.Add(LabelGameVersion);
            Controls.Add(btnPlay);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private Label LabelGameVersion;
        private Label Nickname;
        private TextBox txtNickname;
        private ProgressBar progressBar;
        private Label NameLauncher;
        private Button btnSettings;
        private Button btnSaveNickname;
        private ComboBox cmbVersion;
        private Label statusLabel;
    }
}
