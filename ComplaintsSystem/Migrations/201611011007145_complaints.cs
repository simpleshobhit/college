namespace ComplaintsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complaints : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Year = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Email = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TicketType = c.String(),
                        StudentId = c.Int(nullable: false),
                        Description = c.String(),
                        StatusId = c.Int(nullable: false),
                        ActionComments = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.TicketStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.TicketStatus");
            DropForeignKey("dbo.Tickets", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "CourseId", "dbo.Courses");
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.Tickets", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "CourseId" });
            DropTable("dbo.TicketStatus");
            DropTable("dbo.Tickets");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Branches");
        }
    }
}
