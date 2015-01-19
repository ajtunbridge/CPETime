using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CPETime
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var listener = new TextWriterTraceListener("error.log");
            Trace.Listeners.Add(listener);

            SetSystemTimeViaInternetService();

            var timeUpdateTimer = new Timer();
            timeUpdateTimer.Tick += timer_Tick;
            timeUpdateTimer.Interval = 60000; // check system time every minute
            timeUpdateTimer.Start();

            Application.Run(new KioskForm());

            timeUpdateTimer.Dispose();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            SetSystemTimeViaInternetService();
        }

        private static void SetSystemTimeViaInternetService()
        {
            try {
                var client = new TcpClient("time.nist.gov", 13);

                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();

                    var utcDateTimeString = response.Substring(7, 17);

                    var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss",
                        CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

                    var correctSystemTime = new SYSTEMTIME();
                    correctSystemTime.wYear = (short)localDateTime.Year;
                    correctSystemTime.wMonth = (short)localDateTime.Month;
                    correctSystemTime.wDay = (short)localDateTime.Day;
                    correctSystemTime.wHour = (short)localDateTime.Hour;
                    correctSystemTime.wMinute = (short)localDateTime.Minute;
                    correctSystemTime.wSecond = (short)localDateTime.Second;

                    SetSystemTime(ref correctSystemTime);
                }
            }
            catch (Exception ex) {
                Trace.WriteLine(DateTime.Now + ": Unable to retrieve correct time via internet", "Exception");
                Trace.Indent();
                Trace.WriteLine(ex.Message);
                Trace.WriteLine(ex.StackTrace);
                Trace.WriteLine(string.Empty);
                Trace.Unindent();
                Trace.Flush();
            }

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
        }
    }
}
