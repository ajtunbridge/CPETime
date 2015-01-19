#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPETime.Data.EntityFramework.Commands;
using CPETime.Data.EntityFramework.Model;
using CPETime.Data.EntityFramework.Queries;
using CPETime.Domain;
using CPETime.ViewModels;
using CPETime.Views;

#endregion

namespace CPETime.Presenters
{
    public class KioskMainViewPresenter
    {
        private readonly KioskMainView _view;

        public KioskMainViewPresenter(KioskMainView view)
        {
            _view = view;

            _view.ClockInOrOut += ViewClockInOrOut;
        }

        private void ViewClockInOrOut(object sender, StringEventArgs e)
        {
            int employeeId = Convert.ToInt32(e.Value.Substring(3));

            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(employeeId);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                var ex = e.Result as Exception;
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                MessageBox.Show(msg);
                return;
            }

            if (e.Result is KioskMainViewClockedInModel) {
                _view.HandleClockInOutResult((KioskMainViewClockedInModel) e.Result);
            }
            else {
                _view.HandleClockInOutResult((KioskMainViewClockedOutModel) e.Result);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                var employeeId = (int) e.Argument;

                var getEmployeeQuery = new GetEmployeeByIdQuery(employeeId);

                Employee employee = getEmployeeQuery.ExecuteQuery();

                if (employee == null) {
                    throw new Exception("Unable to match ID card to an employee!");
                }

                var updateClockEntryCommand = new UpdateClockEntryCommand(employee);

                ClockEntryAction entryAction = updateClockEntryCommand.ExecuteCommand();

                TimeSpan timeWorkedSoFar = new GetHoursWorkedThisWeekQuery(employee).ExecuteQuery();

                double hoursLeftThisWeek = employee.HoursPerWeek - timeWorkedSoFar.TotalHours;

                if (entryAction == ClockEntryAction.ClockedIn) {
                    var getEmployeeBreaksQuery = new GetEmployeeBreaksQuery(employee);

                    IList<Break> employeeBreaks = getEmployeeBreaksQuery.ExecuteQuery();

                    var totalUnpaidBreakTime = new TimeSpan();

                    foreach (Break @break in employeeBreaks.Where(eb => !eb.IsPaid)) {
                        totalUnpaidBreakTime = totalUnpaidBreakTime.Add(@break.EndTime.Subtract(@break.StartTime));
                    }

                    DateTime shiftDoneAt = DateTime.Now.AddHours(employee.BasicShiftHours)
                        .AddMinutes(totalUnpaidBreakTime.TotalMinutes)
                        .AddSeconds(totalUnpaidBreakTime.TotalSeconds);

                    var viewModel = new KioskMainViewClockedInModel(employee, shiftDoneAt, hoursLeftThisWeek);

                    e.Result = viewModel;
                }
                else {
                    var getEmployeeBreaksQuery = new GetEmployeeBreaksQuery(employee);

                    IList<Break> employeeBreaks = getEmployeeBreaksQuery.ExecuteQuery();

                    var totalUnpaidBreakTime = new TimeSpan();

                    foreach (Break @break in employeeBreaks.Where(eb => !eb.IsPaid)) {
                        totalUnpaidBreakTime = totalUnpaidBreakTime.Add(@break.EndTime.Subtract(@break.StartTime));
                    }

                    ClockEntry lastEntry = new CPETimeEntities().ClockEntries
                        .Where(ce => ce.EmployeeId == employee.Id)
                        .OrderByDescending(ce => ce.ActualStart)
                        .FirstOrDefault();

                    if (lastEntry == null || !lastEntry.ActualEnd.HasValue) {
                        throw new Exception("No clock entry or invalid clock entry!");
                    }

                    TimeSpan timeDiff = lastEntry.ActualEnd.Value.Subtract(lastEntry.ActualStart);

                    timeDiff = timeDiff.Subtract(totalUnpaidBreakTime);

                    var viewModel = new KioskMainViewClockedOutModel(employee, timeDiff.TotalHours, hoursLeftThisWeek);

                    e.Result = viewModel;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }
    }
}