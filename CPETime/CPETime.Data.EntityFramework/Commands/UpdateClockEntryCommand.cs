#region Using directives

using System;
using System.Linq;
using CPETime.Data.EntityFramework.Model;
using CPETime.Domain;

#endregion

namespace CPETime.Data.EntityFramework.Commands
{
    public class UpdateClockEntryCommand
    {
        private readonly Employee _employee;

        public UpdateClockEntryCommand(Employee employee)
        {
            _employee = employee;
        }

        public ClockEntryAction ExecuteCommand()
        {
            var action = ClockEntryAction.ClockedIn;

            using (var model = new CPETimeModelContainer()) {
                ClockEntry lastClockEntry = model.ClockEntries
                    .Where(c => c.EmployeeId == _employee.Id)
                    .OrderByDescending(c => c.ActualStart)
                    .FirstOrDefault();

                if (lastClockEntry == null // first time clocking in
                    || lastClockEntry.ActualEnd.HasValue // already clocked out
                    || lastClockEntry.ActualStart.Date < DateTime.Today && !_employee.IsNightShift) {
                    // forgot to clock out yesterday
                    // employee is clocking in
                    var clockEntry = new ClockEntry {
                        EmployeeId = _employee.Id,
                        ActualStart = DateTime.Now
                    };
                    model.ClockEntries.Add(clockEntry);
                }
                else {
                    // employee is clocking out
                    lastClockEntry.ActualEnd = DateTime.Now;

                    action = ClockEntryAction.ClockedOut;
                }

                model.SaveChanges();
            }

            return action;
        }
    }
}