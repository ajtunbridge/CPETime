#region Using directives

using System;
using CPETime.Data.EntityFramework.Model;
using CPETime.Domain;

#endregion

namespace CPETime.ViewModels
{
    public class KioskMainViewClockedOutModel
    {
        private readonly Employee _employee;
        private readonly double _hoursWorked;
        private readonly double _hoursLeftThisWeek;

        public KioskMainViewClockedOutModel(Employee employee, double hoursWorked, double hoursLeftThisWeek)
        {
            _employee = employee;
            _hoursWorked = hoursWorked;
            _hoursLeftThisWeek = hoursLeftThisWeek;
        }

        public Employee Employee
        {
            get { return _employee; }
        }

        public double HoursWorked
        {
            get { return _hoursWorked; }
        }

        public double HoursLeftThisWeek
        {
            get { return _hoursLeftThisWeek; }
        }
    }
}