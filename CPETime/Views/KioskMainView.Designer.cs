namespace CPETime.Views
{
    sealed partial class KioskMainView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.centralPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showTimeSheetsRadioButton = new System.Windows.Forms.RadioButton();
            this.clockInOutRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.messageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.minimizePictureBox = new System.Windows.Forms.PictureBox();
            this.closeButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.centralPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // centralPanel
            // 
            this.centralPanel.Controls.Add(this.pictureBox2);
            this.centralPanel.Controls.Add(this.groupBox1);
            this.centralPanel.Controls.Add(this.pictureBox1);
            this.centralPanel.Controls.Add(this.progressBar);
            this.centralPanel.Controls.Add(this.messageLabel);
            this.centralPanel.Controls.Add(this.label2);
            this.centralPanel.Controls.Add(this.statusLabel);
            this.centralPanel.Location = new System.Drawing.Point(34, 34);
            this.centralPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Size = new System.Drawing.Size(498, 668);
            this.centralPanel.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CPETime.Properties.Resources.AppIconImage;
            this.pictureBox2.Location = new System.Drawing.Point(68, 24);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showTimeSheetsRadioButton);
            this.groupBox1.Controls.Add(this.clockInOutRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(57, 340);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // showTimeSheetsRadioButton
            // 
            this.showTimeSheetsRadioButton.AutoSize = true;
            this.showTimeSheetsRadioButton.Location = new System.Drawing.Point(197, 26);
            this.showTimeSheetsRadioButton.Name = "showTimeSheetsRadioButton";
            this.showTimeSheetsRadioButton.Size = new System.Drawing.Size(145, 25);
            this.showTimeSheetsRadioButton.TabIndex = 1;
            this.showTimeSheetsRadioButton.Text = "View time sheets";
            this.showTimeSheetsRadioButton.UseVisualStyleBackColor = true;
            // 
            // clockInOutRadioButton
            // 
            this.clockInOutRadioButton.AutoSize = true;
            this.clockInOutRadioButton.Checked = true;
            this.clockInOutRadioButton.Location = new System.Drawing.Point(45, 26);
            this.clockInOutRadioButton.Name = "clockInOutRadioButton";
            this.clockInOutRadioButton.Size = new System.Drawing.Size(112, 25);
            this.clockInOutRadioButton.TabIndex = 0;
            this.clockInOutRadioButton.TabStop = true;
            this.clockInOutRadioButton.Text = "Clock in/out";
            this.clockInOutRadioButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CPETime.Properties.Resources.CPE;
            this.pictureBox1.Location = new System.Drawing.Point(141, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(57, 290);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(384, 31);
            this.progressBar.TabIndex = 2;
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.messageLabel.Location = new System.Drawing.Point(5, 419);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(489, 246);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(489, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Time Recording";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.statusLabel.Location = new System.Drawing.Point(4, 216);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(489, 32);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Awaiting ID card scan....";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minimizePictureBox
            // 
            this.minimizePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizePictureBox.Image = global::CPETime.Properties.Resources.MinimizeNormal;
            this.minimizePictureBox.Location = new System.Drawing.Point(699, 24);
            this.minimizePictureBox.Margin = new System.Windows.Forms.Padding(20);
            this.minimizePictureBox.Name = "minimizePictureBox";
            this.minimizePictureBox.Size = new System.Drawing.Size(41, 41);
            this.minimizePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizePictureBox.TabIndex = 2;
            this.minimizePictureBox.TabStop = false;
            this.minimizePictureBox.Click += new System.EventHandler(this.minimizePictureBox_Click);
            this.minimizePictureBox.MouseEnter += new System.EventHandler(this.minimizePictureBox_MouseEnter);
            this.minimizePictureBox.MouseLeave += new System.EventHandler(this.minimizePictureBox_MouseLeave);
            // 
            // closeButtonPictureBox
            // 
            this.closeButtonPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonPictureBox.Image = global::CPETime.Properties.Resources.CloseButtonNormal;
            this.closeButtonPictureBox.Location = new System.Drawing.Point(756, 20);
            this.closeButtonPictureBox.Margin = new System.Windows.Forms.Padding(20);
            this.closeButtonPictureBox.Name = "closeButtonPictureBox";
            this.closeButtonPictureBox.Size = new System.Drawing.Size(48, 48);
            this.closeButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeButtonPictureBox.TabIndex = 1;
            this.closeButtonPictureBox.TabStop = false;
            this.closeButtonPictureBox.Click += new System.EventHandler(this.closeButtonPictureBox_Click);
            this.closeButtonPictureBox.MouseEnter += new System.EventHandler(this.closeButtonPictureBox_MouseEnter);
            this.closeButtonPictureBox.MouseLeave += new System.EventHandler(this.closeButtonPictureBox_MouseLeave);
            // 
            // KioskMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.minimizePictureBox);
            this.Controls.Add(this.closeButtonPictureBox);
            this.Controls.Add(this.centralPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "KioskMainView";
            this.Size = new System.Drawing.Size(824, 707);
            this.Load += new System.EventHandler(this.KioskMainView_Load);
            this.Resize += new System.EventHandler(this.KioskMainView_Resize);
            this.centralPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel centralPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton showTimeSheetsRadioButton;
        private System.Windows.Forms.RadioButton clockInOutRadioButton;
        private System.Windows.Forms.PictureBox closeButtonPictureBox;
        private System.Windows.Forms.PictureBox minimizePictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;


    }
}
