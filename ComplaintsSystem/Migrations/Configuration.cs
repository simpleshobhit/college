namespace ComplaintsSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComplaintsSystem.Models.ComplaintsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ComplaintsSystem.Models.ComplaintsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (context.course.Count() == 0)
            {
                context.course.Add(new Models.Course { CourseName = "B.Tech" });
                context.course.Add(new Models.Course { CourseName = "M.B.A" });
                context.course.Add(new Models.Course { CourseName = "Hotel Management" });
                context.course.Add(new Models.Course { CourseName = "B.Tech + M.B.A" });
                context.SaveChanges();
            }
            if (context.branch.Count() == 0)
            {
                context.branch.Add(new Models.Branch { BranchName = "Computer Science & Engg", CourseId = 1 });
                context.branch.Add(new Models.Branch { BranchName = "Electrical Engg", CourseId = 1 });
                context.SaveChanges();
            }
            if (context.students.Count() == 0)
            {
                context.students.Add(new Models.Student { StudentName = "Ishika", Year = 4, BranchId = 2, CourseId = 1, Email = "xxx@xx.xx", Mobile = "1234567891" });
                context.students.Add(new Models.Student { StudentName = "Suresh", Year = 3, BranchId = 2, CourseId = 1, Email = "xxx@xx.xx", Mobile = "1234567891" });
                context.students.Add(new Models.Student { StudentName = "Mahesh", Year = 2, BranchId = 2, CourseId = 1, Email = "xxx@xx.xx", Mobile = "1234567891" });
                context.students.Add(new Models.Student { StudentName = "Sanjana", Year = 4, BranchId = 1, CourseId = 1, Email = "xxx@xx.xx", Mobile = "1234567891" });
                context.students.Add(new Models.Student { StudentName = "Rajesh", Year = 4, BranchId = 1, CourseId = 1, Email = "xxx@xx.xx", Mobile = "1234567891" });
                context.students.Add(new Models.Student { StudentName = "Varun", Year = 4, BranchId = 1, CourseId = 1, Email = "xxx@xx.xx", Mobile = "1234567891" });
                context.SaveChanges();
            }
            if (context.ticketStatus.Count() == 0)
            {
                context.ticketStatus.Add(new Models.TicketStatus { Status = "Created" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "Rejected" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "In-Progress" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "Resolved" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "Mentor" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "HOD" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "Director" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "D.R" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "V.C" });
                context.ticketStatus.Add(new Models.TicketStatus { Status = "Chancellor" });
                context.SaveChanges();
            }
            if (context.complaintType.Count() == 0)
            {
                context.complaintType.Add(new Models.ComplaintTypes { ComplaintTypeName = "Hostel" });
                context.complaintType.Add(new Models.ComplaintTypes { ComplaintTypeName = "Academics" });
                context.complaintType.Add(new Models.ComplaintTypes { ComplaintTypeName = "Administration" });
                context.complaintType.Add(new Models.ComplaintTypes { ComplaintTypeName = "Security" });
                context.complaintType.Add(new Models.ComplaintTypes { ComplaintTypeName = "Miscellanious" });
                context.SaveChanges();
            }
            if (context.userRoles.Count()==0) {
                context.userRoles.Add(new Models.UserRoles { RoleName = "Admin" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "Student" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "Mentor" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "HOD" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "Director" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "D.R" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "V.C" });
                context.userRoles.Add(new Models.UserRoles { RoleName = "Chancellor" });
                context.SaveChanges();
            }
        }
    }
}
