using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPETime.Domain;
using CPETime.Presenters;
using CPETime.ViewModels;

namespace CPETime.Views
{
    public sealed partial class KioskMainView : UserControl
    {
        private readonly KioskMainViewPresenter _presenter;
        private bool _processingInProgress;
        private string _barcodeValue;

        public event EventHandler<StringEventArgs> IdCardScanned;

        public KioskMainView()
        {
            InitializeComponent();
            _presenter = new KioskMainViewPresenter(this);
        }

        private void KioskMainView_Resize(object sender, EventArgs e)
        {
            centralPanel.Left = Convert.ToInt32((Width/2) - centralPanel.Width/2);
            centralPanel.Top = Convert.ToInt32((Height/2) - centralPanel.Height/2);
        }

        private void ProcessIdCardScan()
        {
            statusLabel.Text = "processing....";
            progressBar.Style = ProgressBarStyle.Marquee;
            _processingInProgress = true;

            OnIdCardScanned(new StringEventArgs(_barcodeValue));    
        }

        public void HandleIdCardScanResult(KioskMainViewClockedInModel model)
        {
            progressBar.Style = ProgressBarStyle.Blocks;

            statusLabel.Text = "You have clocked in successfully.";

            messageLabel.Text = string.Format("Hello {0}!\n\nYou will have done your hours at {1} on {2}.",
                model.Employee.FirstName, model.ShiftFinishedAt.ToShortTimeString(),
                model.ShiftFinishedAt.ToShortDateString());

            if (model.HoursLeftThisWeek < 0) {
                messageLabel.Text += string.Format("\n\nYou have done {0:0.00} hours overtime so far this week!", model.HoursLeftThisWeek);
            }
            else {
                messageLabel.Text += string.Format("\n\nYou still have {0:0.00} hours to do this week!", model.HoursLeftThisWeek);
            }

            _processingInProgress = false;
        }

        public void HandleIdCardScanResult(KioskMainViewClockedOutModel model)
        {
            progressBar.Style = ProgressBarStyle.Blocks;

            statusLabel.Text = "You have clocked out successfully.";

            //var hoursToNearestQuarter = Math.Round(model.HoursWorked * 4, MidpointRounding.ToEven) / 4;

            messageLabel.Text =
                string.Format("Goodbye {0}!\n\nYou worked for a total of {1:0.00} hours today, including breaks.",
                    model.Employee.FirstName, model.HoursWorked);

            if (model.HoursLeftThisWeek < 0) {
                messageLabel.Text += string.Format("\n\nYou have done {0:0.00} hours overtime so far this week!",
                    model.HoursLeftThisWeek);
            }
            else {
                messageLabel.Text += string.Format("\n\nYou still have {0:0.00} hours to do this week!",
                    model.HoursLeftThisWeek);
            }

            _processingInProgress = false;
        }

        private void OnIdCardScanned(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = IdCardScanned;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void KioskMainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (_processingInProgress) {
                return;
            }

            // listen for the barcode value in format EID###
            if (string.IsNullOrWhiteSpace(_barcodeValue))
            {
                if (e.KeyCode == Keys.E)
                {
                    _barcodeValue = "E";
                }
                e.Handled = true;
            }
            else
            {
                if (_barcodeValue.Length == 1 && e.KeyCode == Keys.I)
                {
                    _barcodeValue += "I";
                    e.Handled = true;
                }
                else if (_barcodeValue.Length == 2 && e.KeyCode == Keys.D)
                {
                    _barcodeValue += "D";
                    e.Handled = true;
                }
                else if (_barcodeValue.Length == 3 || _barcodeValue.Length == 4 || _barcodeValue.Length == 5)
                {
                    var c = (char)e.KeyValue;
                    if (char.IsNumber(c))
                    {
                        _barcodeValue += c;
                    }

                    if (_barcodeValue.Length == 6) {
                        ProcessIdCardScan();
                        _barcodeValue = null;
                    }

                    e.Handled = true;
                }
            }
        }
    }
}
