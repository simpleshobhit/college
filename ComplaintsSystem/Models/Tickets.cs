using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class Tickets
    {
        public int ID { get; set; }
        public int ComplaintTypeId { get; set; }
        public int StudentId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public string ActionComments { get; set; }
        public ComplaintTypes ComplaintType { get; set; }
    }
}