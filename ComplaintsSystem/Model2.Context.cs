﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComplaintsSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComplaintsDataEntities : DbContext
    {
        public ComplaintsDataEntities()
            : base("name=ComplaintsDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketStatu> TicketStatus { get; set; }
    }
}
