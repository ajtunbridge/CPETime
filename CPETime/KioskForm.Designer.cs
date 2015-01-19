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
            this.kioskMainView = new CPETime.Views.KioskMainView();
            this.SuspendLayout();
            // 
            // kioskMainView
            // 
            this.kioskMainView.BackColor = System.Drawing.Color.White;
            this.kioskMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kioskMainView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kioskMainView.Location = new System.Drawing.Point(0, 0);
            this.kioskMainView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kioskMainView.Name = "kioskMainView";
            this.kioskMainView.Size = new System.Drawing.Size(1097, 784);
            this.kioskMainView.TabIndex = 0;
            this.kioskMainView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kioskMainView_MouseDown);
            // 
            // KioskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 784);
            this.Controls.Add(this.kioskMainView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "KioskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPE Time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KioskForm_FormClosing);
            this.Load += new System.EventHandler(this.KioskForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KioskForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.KioskMainView kioskMainView;



    }
}