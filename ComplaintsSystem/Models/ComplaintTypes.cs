using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class ComplaintTypes
    {
        [Key]
        public int ComplaintTypeId { get; set; }
        public string ComplaintTypeName { get; set; }
        public ICollection<Tickets> tickets { get; set; }
    }
}