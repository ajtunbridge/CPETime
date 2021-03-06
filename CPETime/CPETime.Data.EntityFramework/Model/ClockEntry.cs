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
    
    public partial class ClockEntry
    {
        public ClockEntry()
        {
            this.BreakAdjustments = new HashSet<BreakAdjustment>();
        }
    
        public int Id { get; set; }
        public System.DateTime ActualStart { get; set; }
        public Nullable<System.DateTime> ModifiedStart { get; set; }
        public Nullable<System.DateTime> ActualEnd { get; set; }
        public Nullable<System.DateTime> ModifiedEnd { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual ICollection<BreakAdjustment> BreakAdjustments { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
