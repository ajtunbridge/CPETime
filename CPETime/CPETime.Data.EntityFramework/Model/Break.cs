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
    
    public partial class Break
    {
        public Break()
        {
            this.EmployeeBreaks = new HashSet<EmployeeBreak>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public bool IsPaid { get; set; }
    
        public virtual ICollection<EmployeeBreak> EmployeeBreaks { get; set; }
    }
}
