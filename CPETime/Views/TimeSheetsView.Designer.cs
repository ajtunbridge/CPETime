namespace CPETime.Views
{
    partial class TimeSheetsView
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
            this.backButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.centralPanel = new System.Windows.Forms.Panel();
            this.presetTimePeriodComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endOnDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPictureBox)).BeginInit();
            this.centralPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // backButtonPictureBox
            // 
            this.backButtonPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButtonPictureBox.Image = global::CPETime.Properties.Resources.BackButtonNormal;
            this.backButtonPictureBox.Location = new System.Drawing.Point(940, 20);
            this.backButtonPictureBox.Margin = new System.Windows.Forms.Padding(20);
            this.backButtonPictureBox.Name = "backButtonPictureBox";
            this.backButtonPictureBox.Size = new System.Drawing.Size(48, 48);
            this.backButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backButtonPictureBox.TabIndex = 2;
            this.backButtonPictureBox.TabStop = false;
            this.backButtonPictureBox.Click += new System.EventHandler(this.backButtonPictureBox_Click);
            this.backButtonPictureBox.MouseEnter += new System.EventHandler(this.backButtonPictureBox_MouseEnter);
            this.backButtonPictureBox.MouseLeave += new System.EventHandler(this.backButtonPictureBox_MouseLeave);
            // 
            // centralPanel
            // 
            this.centralPanel.Controls.Add(this.presetTimePeriodComboBox);
            this.centralPanel.Controls.Add(this.label4);
            this.centralPanel.Controls.Add(this.label3);
            this.centralPanel.Controls.Add(this.label2);
            this.centralPanel.Controls.Add(this.endOnDateTimePicker);
            this.centralPanel.Controls.Add(this.startFromDateTimePicker);
            this.centralPanel.Controls.Add(this.dataGridView1);
            this.centralPanel.Controls.Add(this.label1);
            this.centralPanel.Location = new System.Drawing.Point(28, 58);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Size = new System.Drawing.Size(868, 526);
            this.centralPanel.TabIndex = 3;
            // 
            // presetTimePeriodComboBox
            // 
            this.presetTimePeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetTimePeriodComboBox.FormattingEnabled = true;
            this.presetTimePeriodComboBox.Items.AddRange(new object[] {
            "This week",
            "Last week",
            "This month",
            "Last month"});
            this.presetTimePeriodComboBox.Location = new System.Drawing.Point(459, 486);
            this.presetTimePeriodComboBox.Name = "presetTimePeriodComboBox";
            this.presetTimePeriodComboBox.Size = new System.Drawing.Size(395, 29);
            this.presetTimePeriodComboBox.TabIndex = 13;
            this.presetTimePeriodComboBox.SelectedIndexChanged += new System.EventHandler(this.presetTimePeriodComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Choose preset period";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ending on";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Starting from";
            // 
            // endOnDateTimePicker
            // 
            this.endOnDateTimePicker.Location = new System.Drawing.Point(236, 486);
            this.endOnDateTimePicker.Name = "endOnDateTimePicker";
            this.endOnDateTimePicker.Size = new System.Drawing.Size(200, 29);
            this.endOnDateTimePicker.TabIndex = 9;
            // 
            // startFromDateTimePicker
            // 
            this.startFromDateTimePicker.Location = new System.Drawing.Point(10, 486);
            this.startFromDateTimePicker.Name = "startFromDateTimePicker";
            this.startFromDateTimePicker.Size = new System.Drawing.Size(200, 29);
            this.startFromDateTimePicker.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(844, 394);
            this.dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Time sheets for {0}";
            // 
            // TimeSheetsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.centralPanel);
            this.Controls.Add(this.backButtonPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TimeSheetsView";
            this.Size = new System.Drawing.Size(1008, 712);
            this.Load += new System.EventHandler(this.TimeSheetsView_Load);
            this.Resize += new System.EventHandler(this.TimeSheetsView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPictureBox)).EndInit();
            this.centralPanel.ResumeLayout(false);
            this.centralPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backButtonPictureBox;
        private System.Windows.Forms.Panel centralPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endOnDateTimePicker;
        private System.Windows.Forms.DateTimePicker startFromDateTimePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox presetTimePeriodComboBox;
        private System.Windows.Forms.Label label4;
    }
}
