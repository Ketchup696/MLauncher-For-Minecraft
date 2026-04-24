namespace MoonLauncher
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            labelSettings = new Label();
            LabelRAM = new Label();
            numMemory = new NumericUpDown();
            labelRAMWarning = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            btnBrowse = new Button();
            txtGamePath = new TextBox();
            labelParhDirectoryGame = new Label();
            ((System.ComponentModel.ISupportInitialize)numMemory).BeginInit();
            SuspendLayout();
            // 
            // labelSettings
            // 
            labelSettings.AutoSize = true;
            labelSettings.Font = new Font("Segoe UI", 11F);
            labelSettings.Location = new Point(95, 9);
            labelSettings.Name = "labelSettings";
            labelSettings.Size = new Size(125, 20);
            labelSettings.TabIndex = 0;
            labelSettings.Text = "Launcher Settings";
            // 
            // LabelRAM
            // 
            LabelRAM.AutoSize = true;
            LabelRAM.Location = new Point(6, 51);
            LabelRAM.Name = "LabelRAM";
            LabelRAM.Size = new Size(114, 15);
            LabelRAM.TabIndex = 1;
            LabelRAM.Text = "RAM allocation (GB)";
            // 
            // numMemory
            // 
            numMemory.Location = new Point(139, 49);
            numMemory.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numMemory.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numMemory.Name = "numMemory";
            numMemory.Size = new Size(50, 23);
            numMemory.TabIndex = 2;
            numMemory.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // labelRAMWarning
            // 
            labelRAMWarning.AutoSize = true;
            labelRAMWarning.Location = new Point(6, 85);
            labelRAMWarning.Name = "labelRAMWarning";
            labelRAMWarning.Size = new Size(304, 30);
            labelRAMWarning.TabIndex = 3;
            labelRAMWarning.Text = "If you're unsure how to use this setting, just leave it as is.\r\n\r\n";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(230, 210);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(230, 148);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 6;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtGamePath
            // 
            txtGamePath.Location = new Point(6, 148);
            txtGamePath.Name = "txtGamePath";
            txtGamePath.ReadOnly = true;
            txtGamePath.Size = new Size(214, 23);
            txtGamePath.TabIndex = 7;
            // 
            // labelParhDirectoryGame
            // 
            labelParhDirectoryGame.AutoSize = true;
            labelParhDirectoryGame.Location = new Point(6, 126);
            labelParhDirectoryGame.Name = "labelParhDirectoryGame";
            labelParhDirectoryGame.Size = new Size(199, 15);
            labelParhDirectoryGame.TabIndex = 8;
            labelParhDirectoryGame.Text = "The path to The directory .minecraft:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(317, 245);
            Controls.Add(labelParhDirectoryGame);
            Controls.Add(txtGamePath);
            Controls.Add(btnBrowse);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(labelRAMWarning);
            Controls.Add(numMemory);
            Controls.Add(LabelRAM);
            Controls.Add(labelSettings);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SettingsForm";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)numMemory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSettings;
        private Label LabelRAM;
        private NumericUpDown numMemory;
        private Label labelRAMWarning;
        private Button btnSave;
        private Button btnCancel;
        private Button btnBrowse;
        private TextBox txtGamePath;
        private Label labelParhDirectoryGame;
    }
}