using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPETime.Data.EntityFramework.Commands;
using CPETime.Data.EntityFramework.Model;
using CPETime.Data.EntityFramework.Queries;
using CPETime.Domain;
using CPETime.ViewModels;
using CPETime.Views;

namespace CPETime.Presenters
{
    public class KioskMainViewPresenter
    {
        private readonly KioskMainView _view;

        public KioskMainViewPresenter(KioskMainView view)
        {
            _view = view;

            _view.IdCardScanned += View_IdCardScanned;
        }

        void View_IdCardScanned(object sender, StringEventArgs e)
        {
            var employeeId = Convert.ToInt32(e.Value.Substring(3));

            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(employeeId);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                var ex = e.Result as Exception;
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                MessageBox.Show(msg);
                return;
            }
            
            if (e.Result is KioskMainViewClockedInModel) {
                _view.HandleIdCardScanResult((KioskMainViewClockedInModel) e.Result);
            }
            else {
                _view.HandleIdCardScanResult((KioskMainViewClockedOutModel) e.Result);
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                var employeeId = (int) e.Argument;

                var getEmployeeQuery = new GetEmployeeByIdQuery(employeeId);

                var employee = getEmployeeQuery.ExecuteQuery();

                if (employee == null) {
                    throw new Exception("Unable to match ID card to an employee!");
                }

                var updateClockEntryCommand = new UpdateClockEntryCommand(employee);

                var entryAction = updateClockEntryCommand.ExecuteCommand();

                var timeWorkedSoFar = new GetHoursWorkedThisWeekQuery(employee).ExecuteQuery();

                var hoursLeftThisWeek = employee.HoursPerWeek - timeWorkedSoFar.TotalHours;

                if (entryAction == ClockEntryAction.ClockedIn) {
                    var getEmployeeBreaksQuery = new GetEmployeeBreaksQuery(employee);

                    var employeeBreaks = getEmployeeBreaksQuery.ExecuteQuery();

                    var totalUnpaidBreakTime = new TimeSpan();

                    foreach (var @break in employeeBreaks.Where(eb => !eb.IsPaid)) {
                        totalUnpaidBreakTime = totalUnpaidBreakTime.Add(@break.EndTime.Subtract(@break.StartTime));
                    }

                    var shiftDoneAt = DateTime.Now.AddHours(employee.BasicShiftHours)
                        .AddMinutes(totalUnpaidBreakTime.TotalMinutes)
                        .AddSeconds(totalUnpaidBreakTime.TotalSeconds);

                    var viewModel = new KioskMainViewClockedInModel(employee, shiftDoneAt, hoursLeftThisWeek);

                    e.Result = viewModel;
                }
                else {
                    var getEmployeeBreaksQuery = new GetEmployeeBreaksQuery(employee);

                    var employeeBreaks = getEmployeeBreaksQuery.ExecuteQuery();

                    var totalUnpaidBreakTime = new TimeSpan();

                    foreach (var @break in employeeBreaks.Where(eb => !eb.IsPaid))
                    {
                        totalUnpaidBreakTime = totalUnpaidBreakTime.Add(@break.EndTime.Subtract(@break.StartTime));
                    }
                  
                    var lastEntry = new CPETimeModelContainer().ClockEntries
                        .Where(ce => ce.EmployeeId == employee.Id)
                        .OrderByDescending(ce => ce.ActualStart)
                        .FirstOrDefault();

                    if (lastEntry == null || !lastEntry.ActualEnd.HasValue) {
                        throw new Exception("No clock entry or invalid clock entry!");
                    }

                    var timeDiff = lastEntry.ActualEnd.Value.Subtract(lastEntry.ActualStart);

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