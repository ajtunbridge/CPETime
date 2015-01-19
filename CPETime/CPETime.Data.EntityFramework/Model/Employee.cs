//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPETime.Data.EntityFramework.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.ClockEntries = new HashSet<ClockEntry>();
            this.EmployeeBreaks = new HashSet<EmployeeBreak>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool IsNightShift { get; set; }
        public double BasicShiftHours { get; set; }
        public int HoursPerWeek { get; set; }
    
        public virtual ICollection<ClockEntry> ClockEntries { get; set; }
        public virtual ICollection<EmployeeBreak> EmployeeBreaks { get; set; }
    }
}