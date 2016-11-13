using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintsSystem.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public UserRoles Roles { get; set; }
    }
}