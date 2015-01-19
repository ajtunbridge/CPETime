#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using CPETime.Properties;

#endregion

namespace CPETime.Views
{
    public partial class TimeSheetsView : UserControl
    {
        public TimeSheetsView()
        {
            InitializeComponent();
        }

        public event EventHandler BackButtonClicked;

        protected virtual void OnBackButtonClicked()
        {
            EventHandler handler = BackButtonClicked;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void backButtonPictureBox_MouseEnter(object sender, EventArgs e)
        {
            backButtonPictureBox.Image = Resources.BackButtonHighlighted;
        }

        private void backButtonPictureBox_MouseLeave(object sender, EventArgs e)
        {
            backButtonPictureBox.Image = Resources.BackButtonNormal;
        }

        private void backButtonPictureBox_Click(object sender, EventArgs e)
        {
            OnBackButtonClicked();
        }

        private void TimeSheetsView_Load(object sender, EventArgs e)
        {
            presetTimePeriodComboBox.SelectedIndex = 0;
        }

        private void presetTimePeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.MinValue, endDate = DateTime.MinValue;

            switch (presetTimePeriodComboBox.Text) {
                case "This week":
                    startDate = DateTime.Today.StartOfWeek(DayOfWeek.Monday);
                    endDate = startDate.AddDays(6);
                    break;
                case "Last week":
                    startDate = DateTime.Today.StartOfWeek(DayOfWeek.Monday).AddDays(-7);
                    endDate = startDate.AddDays(6);
                    break;
                case "This month":
                    startDate = DateTime.Today.AddDays(DateTime.Today.Day*-1).AddDays(1);
                    endDate = startDate.AddMonths(1).AddDays(-1);
                    break;
                case "Last month":
                    startDate = DateTime.Today.AddDays(DateTime.Today.Day*-1).AddDays(1).AddMonths(-1);
                    endDate = startDate.AddMonths(1).AddDays(-1);
                    break;
            }

            startFromDateTimePicker.Value = startDate;
            endOnDateTimePicker.Value = endDate;
        }

        private void TimeSheetsView_Resize(object sender, EventArgs e)
        {
            centralPanel.Left = Convert.ToInt32((Width/2) - centralPanel.Width/2);
            centralPanel.Top = Convert.ToInt32((Height/2) - centralPanel.Height/2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, Bounds, Color.DimGray, ButtonBorderStyle.Solid);
        }
    }
}