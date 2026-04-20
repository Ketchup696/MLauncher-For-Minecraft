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
            LabelRAMWarning = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numMemory).BeginInit();
            SuspendLayout();
            // 
            // labelSettings
            // 
            labelSettings.AutoSize = true;
            labelSettings.Location = new Point(61, 18);
            labelSettings.Name = "labelSettings";
            labelSettings.Size = new Size(101, 15);
            labelSettings.TabIndex = 0;
            labelSettings.Text = "Launcher Settings";
            // 
            // LabelRAM
            // 
            LabelRAM.AutoSize = true;
            LabelRAM.Location = new Point(12, 58);
            LabelRAM.Name = "LabelRAM";
            LabelRAM.Size = new Size(114, 15);
            LabelRAM.TabIndex = 1;
            LabelRAM.Text = "RAM allocation (GB)";
            // 
            // numMemory
            // 
            numMemory.Location = new Point(160, 56);
            numMemory.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numMemory.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numMemory.Name = "numMemory";
            numMemory.Size = new Size(50, 23);
            numMemory.TabIndex = 2;
            numMemory.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // LabelRAMWarning
            // 
            LabelRAMWarning.AutoSize = true;
            LabelRAMWarning.Location = new Point(3, 82);
            LabelRAMWarning.Name = "LabelRAMWarning";
            LabelRAMWarning.Size = new Size(214, 30);
            LabelRAMWarning.TabIndex = 3;
            LabelRAMWarning.Text = "If you're unsure how to use this setting,\r\njust leave it as is.\r\n";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(17, 128);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(129, 127);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(222, 163);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(LabelRAMWarning);
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
        private Label LabelRAMWarning;
        private Button btnSave;
        private Button btnCancel;
    }
}