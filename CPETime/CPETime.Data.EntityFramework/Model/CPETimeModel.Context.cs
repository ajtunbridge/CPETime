﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CPETimeModelContainer : DbContext
    {
        public CPETimeModelContainer()
            : base("name=CPETimeModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ClockEntry> ClockEntries { get; set; }
        public virtual DbSet<EmployeeBreak> EmployeeBreaks { get; set; }
        public virtual DbSet<BreakAdjustment> BreakAdjustments { get; set; }
        public virtual DbSet<Break> Breaks { get; set; }
    }
}