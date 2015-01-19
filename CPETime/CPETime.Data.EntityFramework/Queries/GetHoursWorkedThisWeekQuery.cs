using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPETime.Data.EntityFramework.Model;

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetHoursWorkedThisWeekQuery
    {
        private readonly Employee _employee;

        public GetHoursWorkedThisWeekQuery(Employee employee)
        {
            _employee = employee;
        }

        public TimeSpan ExecuteQuery()
        {
            using (var model = new CPETimeModelContainer()) {
                var startDate = DateTime.Today.StartOfWeek(DayOfWeek.Monday);

                var clockEntriesThisWeek = model.ClockEntries.Where(
                    ce => ce.EmployeeId == _employee.Id && ce.ActualStart >= startDate && ce.ActualEnd != null);

                var timeWorkedThisWeek = new TimeSpan();

                foreach (var clockEntry in clockEntriesThisWeek) {
                    var startedAt = clockEntry.ModifiedStart ?? clockEntry.ActualStart;
                    var endedAt = clockEntry.ModifiedEnd ?? clockEntry.ActualEnd;

                    var shiftLength = endedAt.Value.Subtract(startedAt);

                    foreach (var breakAdjustment in clockEntry.BreakAdjustments) {
                        var @break = breakAdjustment.EmployeeBreak.Break;
                        var breakLength = @break.EndTime.Subtract(@break.StartTime);

                        if (breakAdjustment.BreakWasSkipped) {
                            shiftLength += breakLength;
                        }
                        else {
                            var adjustedBreakLength =
                                breakAdjustment.ActualEndTime.Subtract(breakAdjustment.ActualStartTime);

                            if (@break.IsPaid) {
                                var timeDiff = adjustedBreakLength - breakLength;
                                shiftLength += timeDiff;
                            }
                            else {
                                shiftLength -= adjustedBreakLength;
                            }
                        }
                    }

                    foreach (var employeeBreak in model.EmployeeBreaks.Where(eb => eb.EmployeeId == _employee.Id))
                    {
                        if (clockEntry.BreakAdjustments.Any(ba => ba.EmployeeBreakId == employeeBreak.Id)) {
                            continue;
                        }

                        var @break = employeeBreak.Break;
                        var breakLength = @break.EndTime.Subtract(@break.StartTime);

                        shiftLength -= breakLength;
                    }

                    timeWorkedThisWeek = timeWorkedThisWeek.Add(shiftLength);
                }

                return timeWorkedThisWeek;
            }
        }
    }
}
