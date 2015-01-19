#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace CPETime
{
    public partial class KioskForm : Form
    {
        private readonly Timer _timeUpdateTimer = new Timer();
        private string _barcodeValue;

        
        public KioskForm()
        {
            InitializeComponent();
        }

        private void KioskForm_Load(object sender, EventArgs e)
        {
            this.GoFullscreen(true);

            _timeUpdateTimer.Interval = 1000;
            _timeUpdateTimer.Tick += _timeUpdateTimer_Tick;
            _timeUpdateTimer.Start();
        }

        private void _timeUpdateTimer_Tick(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KioskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timeUpdateTimer.Dispose();
        }

        private void KioskForm_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}