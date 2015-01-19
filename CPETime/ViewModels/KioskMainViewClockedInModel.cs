#region Using directives

using System;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.ViewModels
{
    public class KioskMainViewClockedInModel
    {
        private readonly Employee _employee;
        private readonly Double _hoursLeftThisWeek;
        private readonly DateTime _shiftFinishedAt;

        public KioskMainViewClockedInModel(Employee employee, DateTime shiftFinishedAt, Double hoursLeftThisWeek)
        {
            _employee = employee;
            _shiftFinishedAt = shiftFinishedAt;
            _hoursLeftThisWeek = hoursLeftThisWeek;
        }

        public Employee Employee
        {
            get { return _employee; }
        }

        public DateTime ShiftFinishedAt
        {
            get { return _shiftFinishedAt; }
        }

        public Double HoursLeftThisWeek
        {
            get { return _hoursLeftThisWeek; }
        }
    }
}