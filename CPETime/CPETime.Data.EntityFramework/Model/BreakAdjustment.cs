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
    
    public partial class BreakAdjustment
    {
        public int Id { get; set; }
        public System.TimeSpan ActualStartTime { get; set; }
        public System.TimeSpan ActualEndTime { get; set; }
        public bool BreakWasSkipped { get; set; }
        public int ClockEntryId { get; set; }
        public int EmployeeBreakId { get; set; }
    
        public virtual EmployeeBreak EmployeeBreak { get; set; }
        public virtual ClockEntry ClockEntry { get; set; }
    }
}
