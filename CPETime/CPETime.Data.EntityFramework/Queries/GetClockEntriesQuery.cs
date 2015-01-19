#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using CPETime.Data.EntityFramework.Model;
using CPETime.Domain;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    /// <summary>
    ///     Calculates how many hours an employee has worked in a given time period.
    ///     Rounds each day to the nearest quarter hour.
    /// </summary>
    public class GetClockEntriesQuery
    {
        private readonly Employee _employee;
        private DateTime _endDate;
        private DateTime _startDate;

        public GetClockEntriesQuery(Employee employee, PresetTimePeriod timePeriod)
        {
            _employee = employee;

            SetupTimePeriod(timePeriod);
        }

        public GetClockEntriesQuery(Employee employee, DateTime startDate, DateTime endDate)
        {
            _employee = employee;
            _startDate = startDate;
            _endDate = endDate;
        }

        public IList<ClockEntry> ExecuteQuery()
        {
            using (var model = new CPETimeModelContainer()) {
                List<ClockEntry> result = model.ClockEntries
                    .Where(c => c.ActualStart.Date >= _startDate && c.ActualStart.Date <= _endDate)
                    .Where(c => c.EmployeeId == _employee.Id)
                    .OrderBy(c => c.ActualStart)
                    .ToList();

                return result;
            }
        }

        private void SetupTimePeriod(PresetTimePeriod timePeriod)
        {
            DateTime today = DateTime.Today;

            var currentMonth = new DateTime(today.Year, today.Month, 1);
            int currentYear = today.Year;

            _startDate = today - new TimeSpan(7, 0, 0, 0);
            _endDate = today;

            switch (timePeriod) {
                case PresetTimePeriod.LastMonth:
                    _startDate = currentMonth.AddMonths(-1);
                    _endDate = currentMonth.AddDays(-1);
                    break;
                case PresetTimePeriod.LastWeek:
                    _startDate = DateTime.Now.AddDays(-(int) DateTime.Now.DayOfWeek - 6);
                    _endDate = DateTime.Now.AddDays(-(int) DateTime.Now.DayOfWeek);
                    break;
                case PresetTimePeriod.ThisMonth:
                    int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth.Month);
                    _startDate = currentMonth;
                    _endDate = new DateTime(currentYear, currentMonth.Month, daysInMonth);
                    break;
                case PresetTimePeriod.ThisWeek:
                    _startDate = today.StartOfWeek(DayOfWeek.Monday);
                    _endDate = today;
                    break;
            }
        }
    }
}