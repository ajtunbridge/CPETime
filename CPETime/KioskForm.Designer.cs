namespace CPETime
{
    partial class KioskForm
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
            this.kioskMainView1 = new CPETime.Views.KioskMainView();
            this.SuspendLayout();
            // 
            // kioskMainView1
            // 
            this.kioskMainView1.BackColor = System.Drawing.Color.White;
            this.kioskMainView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kioskMainView1.Location = new System.Drawing.Point(0, 0);
            this.kioskMainView1.Name = "kioskMainView1";
            this.kioskMainView1.Size = new System.Drawing.Size(621, 416);
            this.kioskMainView1.TabIndex = 0;
            // 
            // KioskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 416);
            this.Controls.Add(this.kioskMainView1);
            this.KeyPreview = true;
            this.Name = "KioskForm";
            this.Text = "CPE Time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KioskForm_FormClosing);
            this.Load += new System.EventHandler(this.KioskForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KioskForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.KioskMainView kioskMainView1;



    }
}