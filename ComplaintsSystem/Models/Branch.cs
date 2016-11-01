using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class Branch
    {
        public Branch() { }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        // [InverseProperty("BranchId")]
        public ICollection<Student> Students { get; set; }
    }
}