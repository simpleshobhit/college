using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class Student
    {
        public Student() { }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Year { get; set; }
        public int BranchId { get; set; }
        public int CourseId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
        public Users User { get; set; }
        public Branch Branch { get; set; }
    }
}