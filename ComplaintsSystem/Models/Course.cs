using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class Course
    {
        public Course() { }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        //[InverseProperty("CourseId")]
        public ICollection<Branch> Branches { get; set; }
    }
}