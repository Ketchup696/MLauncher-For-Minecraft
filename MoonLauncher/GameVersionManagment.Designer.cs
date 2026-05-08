namespace MoonLauncher
{
    partial class GameVersionManagment
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
            labelVersionManagment = new Label();
            cmbSelectVersionForInstall = new ComboBox();
            labelSelectVersionForInstall = new Label();
            btnInstallSelectVersion = new Button();
            chkSnapshot = new CheckBox();
            chkOptifine = new CheckBox();
            SuspendLayout();
            // 
            // labelVersionManagment
            // 
            labelVersionManagment.AutoSize = true;
            labelVersionManagment.Font = new Font("Segoe UI", 11F);
            labelVersionManagment.Location = new Point(55, 12);
            labelVersionManagment.Name = "labelVersionManagment";
            labelVersionManagment.Size = new Size(141, 20);
            labelVersionManagment.TabIndex = 0;
            labelVersionManagment.Text = "Version Managment";
            // 
            // cmbSelectVersionForInstall
            // 
            cmbSelectVersionForInstall.FormattingEnabled = true;
            cmbSelectVersionForInstall.Location = new Point(31, 88);
            cmbSelectVersionForInstall.Name = "cmbSelectVersionForInstall";
            cmbSelectVersionForInstall.Size = new Size(121, 23);
            cmbSelectVersionForInstall.TabIndex = 1;
            // 
            // labelSelectVersionForInstall
            // 
            labelSelectVersionForInstall.AutoSize = true;
            labelSelectVersionForInstall.Font = new Font("Segoe UI", 10F);
            labelSelectVersionForInstall.Location = new Point(39, 57);
            labelSelectVersionForInstall.Name = "labelSelectVersionForInstall";
            labelSelectVersionForInstall.Size = new Size(175, 19);
            labelSelectVersionForInstall.TabIndex = 2;
            labelSelectVersionForInstall.Text = "Select the version to install:";
            // 
            // btnInstallSelectVersion
            // 
            btnInstallSelectVersion.Location = new Point(158, 87);
            btnInstallSelectVersion.Name = "btnInstallSelectVersion";
            btnInstallSelectVersion.Size = new Size(62, 23);
            btnInstallSelectVersion.TabIndex = 3;
            btnInstallSelectVersion.Text = "Install";
            btnInstallSelectVersion.UseVisualStyleBackColor = true;
            // 
            // chkSnapshot
            // 
            chkSnapshot.AutoSize = true;
            chkSnapshot.Location = new Point(41, 118);
            chkSnapshot.Name = "chkSnapshot";
            chkSnapshot.Size = new Size(80, 19);
            chkSnapshot.TabIndex = 4;
            chkSnapshot.Text = "Snapshots";
            chkSnapshot.UseVisualStyleBackColor = true;
            chkSnapshot.CheckedChanged += chkSnapshot_CheckedChanged;
            // 
            // chkOptifine
            // 
            chkOptifine.AutoSize = true;
            chkOptifine.Location = new Point(127, 118);
            chkOptifine.Name = "chkOptifine";
            chkOptifine.Size = new Size(69, 19);
            chkOptifine.TabIndex = 5;
            chkOptifine.Text = "Optifine";
            chkOptifine.UseVisualStyleBackColor = true;
            chkOptifine.CheckedChanged += chkOptifine_CheckedChanged;
            // 
            // GameVersionManagment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(259, 256);
            Controls.Add(chkOptifine);
            Controls.Add(chkSnapshot);
            Controls.Add(btnInstallSelectVersion);
            Controls.Add(labelSelectVersionForInstall);
            Controls.Add(cmbSelectVersionForInstall);
            Controls.Add(labelVersionManagment);
            Name = "GameVersionManagment";
            Text = "Version managment";
            Load += GameVersionManagment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelVersionManagment;
        private ComboBox cmbSelectVersionForInstall;
        private Label labelSelectVersionForInstall;
        private Button btnInstallSelectVersion;
        private CheckBox chkSnapshot;
        private CheckBox chkOptifine;
    }
}