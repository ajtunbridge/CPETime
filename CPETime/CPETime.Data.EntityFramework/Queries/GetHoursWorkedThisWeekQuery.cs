﻿#region Using directives

using System;
using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

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
            using (var model = new CPETimeEntities()) {
                DateTime startDate = DateTime.Today.StartOfWeek(DayOfWeek.Monday);

                IQueryable<ClockEntry> clockEntriesThisWeek = model.ClockEntries.Where(
                    ce => ce.EmployeeId == _employee.Id && ce.ActualStart >= startDate && ce.ActualEnd != null);

                var timeWorkedThisWeek = new TimeSpan();

                foreach (ClockEntry clockEntry in clockEntriesThisWeek) {
                    DateTime startedAt = clockEntry.ModifiedStart ?? clockEntry.ActualStart;
                    DateTime? endedAt = clockEntry.ModifiedEnd ?? clockEntry.ActualEnd;

                    TimeSpan shiftLength = endedAt.Value.Subtract(startedAt);

                    foreach (BreakAdjustment breakAdjustment in clockEntry.BreakAdjustments) {
                        Break @break = breakAdjustment.EmployeeBreak.Break;
                        TimeSpan breakLength = @break.EndTime.Subtract(@break.StartTime);

                        if (breakAdjustment.BreakWasSkipped && @break.IsPaid) {
                            shiftLength += breakLength;
                        }
                        else {
                            TimeSpan adjustedBreakLength =
                                breakAdjustment.ActualEndTime.Subtract(breakAdjustment.ActualStartTime);

                            if (@break.IsPaid) {
                                TimeSpan timeDiff = adjustedBreakLength - breakLength;
                                shiftLength += timeDiff;
                            }
                            else {
                                shiftLength -= adjustedBreakLength;
                            }
                        }
                    }

                    foreach (
                        EmployeeBreak employeeBreak in model.EmployeeBreaks.Where(eb => eb.EmployeeId == _employee.Id)) {
                        if (clockEntry.BreakAdjustments.Any(ba => ba.EmployeeBreakId == employeeBreak.Id)) {
                            continue;
                        }

                        Break @break = employeeBreak.Break;

                        if (@break.IsPaid) {
                            continue;
                        }

                        TimeSpan breakLength = @break.EndTime.Subtract(@break.StartTime);

                        shiftLength -= breakLength;
                    }

                    timeWorkedThisWeek = timeWorkedThisWeek.Add(shiftLength);
                }

                return timeWorkedThisWeek;
            }
        }
    }
}