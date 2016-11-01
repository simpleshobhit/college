using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class ComplaintsDbContext:DbContext
    {
        public ComplaintsDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Tickets> tickets { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Branch> branch { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<TicketStatus> ticketStatus { get; set; }
        public DbSet<ComplaintTypes> complaintType { get; set; }
    }
}