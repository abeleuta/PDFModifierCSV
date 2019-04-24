namespace PDFModifierCSV {
    partial class mainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.footRightCheckbox = new System.Windows.Forms.CheckBox();
            this.footCenterCheckbox = new System.Windows.Forms.CheckBox();
            this.footLeftCheckbox = new System.Windows.Forms.CheckBox();
            this.headRightCheckbox = new System.Windows.Forms.CheckBox();
            this.headCenterCheckBox = new System.Windows.Forms.CheckBox();
            this.headLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.csvPathTextBox = new System.Windows.Forms.TextBox();
            this.selCVSPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // footRightCheckbox
            // 
            this.footRightCheckbox.AutoSize = true;
            this.footRightCheckbox.Checked = true;
            this.footRightCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.footRightCheckbox.Location = new System.Drawing.Point(302, 71);
            this.footRightCheckbox.Name = "footRightCheckbox";
            this.footRightCheckbox.Size = new System.Drawing.Size(84, 17);
            this.footRightCheckbox.TabIndex = 27;
            this.footRightCheckbox.Text = "Footer Right";
            this.footRightCheckbox.UseVisualStyleBackColor = true;
            // 
            // footCenterCheckbox
            // 
            this.footCenterCheckbox.AutoSize = true;
            this.footCenterCheckbox.Checked = true;
            this.footCenterCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.footCenterCheckbox.Location = new System.Drawing.Point(166, 71);
            this.footCenterCheckbox.Name = "footCenterCheckbox";
            this.footCenterCheckbox.Size = new System.Drawing.Size(90, 17);
            this.footCenterCheckbox.TabIndex = 26;
            this.footCenterCheckbox.Text = "Footer Center";
            this.footCenterCheckbox.UseVisualStyleBackColor = true;
            // 
            // footLeftCheckbox
            // 
            this.footLeftCheckbox.AutoSize = true;
            this.footLeftCheckbox.Checked = true;
            this.footLeftCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.footLeftCheckbox.Location = new System.Drawing.Point(34, 71);
            this.footLeftCheckbox.Name = "footLeftCheckbox";
            this.footLeftCheckbox.Size = new System.Drawing.Size(77, 17);
            this.footLeftCheckbox.TabIndex = 25;
            this.footLeftCheckbox.Text = "Footer Left";
            this.footLeftCheckbox.UseVisualStyleBackColor = true;
            // 
            // headRightCheckbox
            // 
            this.headRightCheckbox.AutoSize = true;
            this.headRightCheckbox.Checked = true;
            this.headRightCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headRightCheckbox.Location = new System.Drawing.Point(302, 48);
            this.headRightCheckbox.Name = "headRightCheckbox";
            this.headRightCheckbox.Size = new System.Drawing.Size(89, 17);
            this.headRightCheckbox.TabIndex = 24;
            this.headRightCheckbox.Text = "Header Right";
            this.headRightCheckbox.UseVisualStyleBackColor = true;
            // 
            // headCenterCheckBox
            // 
            this.headCenterCheckBox.AutoSize = true;
            this.headCenterCheckBox.Checked = true;
            this.headCenterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headCenterCheckBox.Location = new System.Drawing.Point(166, 48);
            this.headCenterCheckBox.Name = "headCenterCheckBox";
            this.headCenterCheckBox.Size = new System.Drawing.Size(95, 17);
            this.headCenterCheckBox.TabIndex = 23;
            this.headCenterCheckBox.Text = "Header Center";
            this.headCenterCheckBox.UseVisualStyleBackColor = true;
            // 
            // headLeftCheckBox
            // 
            this.headLeftCheckBox.AutoSize = true;
            this.headLeftCheckBox.Checked = true;
            this.headLeftCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.headLeftCheckBox.Location = new System.Drawing.Point(34, 48);
            this.headLeftCheckBox.Name = "headLeftCheckBox";
            this.headLeftCheckBox.Size = new System.Drawing.Size(82, 17);
            this.headLeftCheckBox.TabIndex = 22;
            this.headLeftCheckBox.Text = "Header Left";
            this.headLeftCheckBox.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(16, 159);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(462, 181);
            this.logTextBox.TabIndex = 21;
            this.logTextBox.WordWrap = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(166, 112);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(97, 31);
            this.startButton.TabIndex = 20;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // csvPathTextBox
            // 
            this.csvPathTextBox.BackColor = System.Drawing.Color.White;
            this.csvPathTextBox.Location = new System.Drawing.Point(12, 12);
            this.csvPathTextBox.Name = "csvPathTextBox";
            this.csvPathTextBox.ReadOnly = true;
            this.csvPathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.csvPathTextBox.Size = new System.Drawing.Size(374, 20);
            this.csvPathTextBox.TabIndex = 28;
            this.csvPathTextBox.WordWrap = false;
            // 
            // selCVSPathButton
            // 
            this.selCVSPathButton.Location = new System.Drawing.Point(392, 10);
            this.selCVSPathButton.Name = "selCVSPathButton";
            this.selCVSPathButton.Size = new System.Drawing.Size(25, 25);
            this.selCVSPathButton.TabIndex = 29;
            this.selCVSPathButton.Text = "...";
            this.selCVSPathButton.UseVisualStyleBackColor = true;
            this.selCVSPathButton.Click += new System.EventHandler(this.selCVSPathButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 346);
            this.Controls.Add(this.selCVSPathButton);
            this.Controls.Add(this.csvPathTextBox);
            this.Controls.Add(this.footRightCheckbox);
            this.Controls.Add(this.footCenterCheckbox);
            this.Controls.Add(this.footLeftCheckbox);
            this.Controls.Add(this.headRightCheckbox);
            this.Controls.Add(this.headCenterCheckBox);
            this.Controls.Add(this.headLeftCheckBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.startButton);
            this.Name = "mainForm";
            this.Text = "PdfModifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox footRightCheckbox;
        private System.Windows.Forms.CheckBox footCenterCheckbox;
        private System.Windows.Forms.CheckBox footLeftCheckbox;
        private System.Windows.Forms.CheckBox headRightCheckbox;
        private System.Windows.Forms.CheckBox headCenterCheckBox;
        private System.Windows.Forms.CheckBox headLeftCheckBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox csvPathTextBox;
        private System.Windows.Forms.Button selCVSPathButton;
    }
}

