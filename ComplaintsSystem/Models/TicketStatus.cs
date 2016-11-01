using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class TicketStatus
    {
        public TicketStatus() { }
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}