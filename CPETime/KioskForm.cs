#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CPETime.Properties;

#endregion

namespace CPETime
{
    public partial class KioskForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private readonly Timer _timeUpdateTimer = new Timer();
        private string _barcodeValue;


        public KioskForm()
        {
            InitializeComponent();
            base.Icon = Resources.AppIcon;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void KioskForm_Load(object sender, EventArgs e)
        {
            // this.GoFullscreen(true);

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

        private void kioskMainView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}