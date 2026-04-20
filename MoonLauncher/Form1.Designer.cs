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
            labelSavedNicknames = new Label();
            txtNewNickname = new TextBox();
            progressBar = new ProgressBar();
            NameLauncher = new Label();
            btnSettings = new Button();
            btnSaveNickname = new Button();
            cmbVersion = new ComboBox();
            statusLabel = new Label();
            cmbNicknames = new ComboBox();
            labelNewNickname = new Label();
            btnDeleteNickname = new Button();
            btnDeleteVersion = new Button();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(37, 178);
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
            // labelSavedNicknames
            // 
            labelSavedNicknames.AutoSize = true;
            labelSavedNicknames.Location = new Point(12, 109);
            labelSavedNicknames.Name = "labelSavedNicknames";
            labelSavedNicknames.Size = new Size(96, 15);
            labelSavedNicknames.TabIndex = 2;
            labelSavedNicknames.Text = "Saved nickname:";
            // 
            // txtNewNickname
            // 
            txtNewNickname.Location = new Point(111, 77);
            txtNewNickname.Name = "txtNewNickname";
            txtNewNickname.Size = new Size(100, 23);
            txtNewNickname.TabIndex = 3;
            txtNewNickname.Text = "Player";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(72, 149);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(170, 23);
            progressBar.TabIndex = 4;
            progressBar.Visible = false;
            // 
            // NameLauncher
            // 
            NameLauncher.AutoSize = true;
            NameLauncher.Location = new Point(81, 13);
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
            btnSettings.Location = new Point(277, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(32, 32);
            btnSettings.TabIndex = 6;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSaveNickname
            // 
            btnSaveNickname.Location = new Point(223, 77);
            btnSaveNickname.Name = "btnSaveNickname";
            btnSaveNickname.Size = new Size(50, 23);
            btnSaveNickname.TabIndex = 7;
            btnSaveNickname.Text = "Save";
            btnSaveNickname.UseVisualStyleBackColor = true;
            btnSaveNickname.Click += btnSaveNickname_Click;
            // 
            // cmbVersion
            // 
            cmbVersion.FormattingEnabled = true;
            cmbVersion.Location = new Point(111, 49);
            cmbVersion.Name = "cmbVersion";
            cmbVersion.Size = new Size(100, 23);
            cmbVersion.TabIndex = 8;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 136);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(28, 15);
            statusLabel.TabIndex = 9;
            statusLabel.Text = "File:";
            statusLabel.Visible = false;
            // 
            // cmbNicknames
            // 
            cmbNicknames.FormattingEnabled = true;
            cmbNicknames.Location = new Point(111, 106);
            cmbNicknames.Name = "cmbNicknames";
            cmbNicknames.Size = new Size(100, 23);
            cmbNicknames.TabIndex = 10;
            // 
            // labelNewNickname
            // 
            labelNewNickname.AutoSize = true;
            labelNewNickname.Location = new Point(45, 80);
            labelNewNickname.Name = "labelNewNickname";
            labelNewNickname.Size = new Size(38, 15);
            labelNewNickname.TabIndex = 11;
            labelNewNickname.Text = "label1";
            // 
            // btnDeleteNickname
            // 
            btnDeleteNickname.Location = new Point(223, 105);
            btnDeleteNickname.Name = "btnDeleteNickname";
            btnDeleteNickname.Size = new Size(50, 23);
            btnDeleteNickname.TabIndex = 12;
            btnDeleteNickname.Text = "Delete";
            btnDeleteNickname.UseVisualStyleBackColor = true;
            btnDeleteNickname.Click += btnDeleteNickname_Click;
            // 
            // btnDeleteVersion
            // 
            btnDeleteVersion.Location = new Point(223, 49);
            btnDeleteVersion.Name = "btnDeleteVersion";
            btnDeleteVersion.Size = new Size(50, 23);
            btnDeleteVersion.TabIndex = 13;
            btnDeleteVersion.Text = "Delete";
            btnDeleteVersion.UseVisualStyleBackColor = true;
            btnDeleteVersion.Click += btnDeleteVersion_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 282);
            Controls.Add(btnDeleteVersion);
            Controls.Add(btnDeleteNickname);
            Controls.Add(labelNewNickname);
            Controls.Add(cmbNicknames);
            Controls.Add(statusLabel);
            Controls.Add(cmbVersion);
            Controls.Add(btnSaveNickname);
            Controls.Add(btnSettings);
            Controls.Add(NameLauncher);
            Controls.Add(progressBar);
            Controls.Add(txtNewNickname);
            Controls.Add(labelSavedNicknames);
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
        private Label labelSavedNicknames;
        private TextBox txtNewNickname;
        private ProgressBar progressBar;
        private Label NameLauncher;
        private Button btnSettings;
        private Button btnSaveNickname;
        private ComboBox cmbVersion;
        private Label statusLabel;
        private ComboBox cmbNicknames;
        private Label labelNewNickname;
        private Button btnDeleteNickname;
        private Button btnDeleteVersion;
    }
}
