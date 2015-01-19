#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using CPETime.Domain;
using CPETime.Presenters;
using CPETime.Properties;
using CPETime.ViewModels;

#endregion

namespace CPETime.Views
{
    public sealed partial class KioskMainView : UserControl
    {
        private readonly KioskMainViewPresenter _presenter;
        private string _barcodeValue;
        private bool _processingInProgress;
        private Timer _resetViewTimer;

        public KioskMainView()
        {
            InitializeComponent();
            _presenter = new KioskMainViewPresenter(this);
        }

        public event EventHandler<StringEventArgs> ClockInOrOut;

        private void KioskMainView_Resize(object sender, EventArgs e)
        {
            centralPanel.Left = Convert.ToInt32((Width/2) - centralPanel.Width/2);
            centralPanel.Top = Convert.ToInt32((Height/2) - centralPanel.Height/2);
        }

        private void ProcessIdCardScan()
        {
            if (clockInOutRadioButton.Checked) {
                statusLabel.Text = "processing....";
                progressBar.Style = ProgressBarStyle.Marquee;
                _processingInProgress = true;

                OnClockInOrOut(new StringEventArgs(_barcodeValue));
            }
            else {
                var timeSheetView = new TimeSheetsView();
                timeSheetView.BackButtonClicked += delegate {
                    Parent.Controls.Remove(timeSheetView);
                    timeSheetView.Dispose();
                };

                Parent.Controls.Add(timeSheetView);
                timeSheetView.Dock = DockStyle.Fill;
                timeSheetView.BringToFront();
            }
        }

        public void HandleClockInOutResult(KioskMainViewClockedInModel model)
        {
            progressBar.Style = ProgressBarStyle.Blocks;

            statusLabel.Text = "You have clocked in successfully.";

            messageLabel.Text = string.Format("Hello {0}!\n\nYou can finish your shift at {1} on {2}.",
                model.Employee.FirstName, model.ShiftFinishedAt.ToShortTimeString(),
                model.ShiftFinishedAt.ToShortDateString());

            if (model.HoursLeftThisWeek < 0) {
                messageLabel.Text += string.Format("\n\nYou have done {0:0.00} hours overtime so far this week!",
                    model.HoursLeftThisWeek);
            }
            else {
                messageLabel.Text += string.Format("\n\nYou have {0:0.00} hours left to do this week!",
                    model.HoursLeftThisWeek);
            }

            _processingInProgress = false;

            StartResetViewTimer();
        }

        public void HandleClockInOutResult(KioskMainViewClockedOutModel model)
        {
            progressBar.Style = ProgressBarStyle.Blocks;

            statusLabel.Text = "You have clocked out successfully.";

            //var hoursToNearestQuarter = Math.Round(model.HoursWorked * 4, MidpointRounding.ToEven) / 4;

            messageLabel.Text =
                string.Format("Goodbye {0}!\n\nYou have worked for a total of {1:0.00} hours today.",
                    model.Employee.FirstName, model.HoursWorked);

            if (model.HoursLeftThisWeek < 0) {
                messageLabel.Text += string.Format("\n\nYou have done {0:0.00} hours overtime so far this week!",
                    model.HoursLeftThisWeek);
            }
            else {
                messageLabel.Text += string.Format("\n\nYou have {0:0.00} hours left to do this week!",
                    model.HoursLeftThisWeek);
            }

            _processingInProgress = false;

            StartResetViewTimer();
        }

        private void StartResetViewTimer()
        {
            _resetViewTimer = new Timer();
            _resetViewTimer.Interval = 8000;

            _resetViewTimer.Tick += delegate {
                Invoke((MethodInvoker) delegate {
                    statusLabel.Text = "Awaiting ID card scan...";
                    messageLabel.Text = string.Empty;
                    clockInOutRadioButton.Checked = true;
                    _resetViewTimer.Dispose();
                });
            };

            _resetViewTimer.Start();
        }

        private void OnClockInOrOut(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = ClockInOrOut;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_processingInProgress) {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            // listen for the barcode value in format EID###
            if (string.IsNullOrWhiteSpace(_barcodeValue)) {
                if (keyData == Keys.E) {
                    _barcodeValue = "E";
                }
            }
            else {
                if (_barcodeValue.Length == 1 && keyData == Keys.I) {
                    _barcodeValue += "I";
                }
                else if (_barcodeValue.Length == 2 && keyData == Keys.D) {
                    _barcodeValue += "D";
                }
                else if (_barcodeValue.Length == 3 || _barcodeValue.Length == 4 || _barcodeValue.Length == 5) {
                    var c = (char) keyData;
                    if (char.IsNumber(c)) {
                        _barcodeValue += c;
                    }

                    if (_barcodeValue.Length == 6) {
                        ProcessIdCardScan();
                        _barcodeValue = string.Empty;
                    }
                }
                else {
                    _barcodeValue = string.Empty;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void KioskMainView_Load(object sender, EventArgs e)
        {
            Focus();
        }

        private void closeButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            closeButtonPictureBox.Image = Resources.CloseButtonHighlighted;
        }

        private void closeButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            closeButtonPictureBox.Image = Resources.CloseButtonNormal;
        }

        private void closeButtonPictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizePictureBox_MouseEnter(object sender, EventArgs e)
        {
            minimizePictureBox.Image = Resources.MinimizeHighlighted;
        }

        private void minimizePictureBox_MouseLeave(object sender, EventArgs e)
        {
            minimizePictureBox.Image = Resources.MinimizeNormal;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, Bounds, Color.DimGray, ButtonBorderStyle.Solid);
        }

        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }
    }
}