namespace ComplaintsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complaintsv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintTypes",
                c => new
                    {
                        ComplaintTypeId = c.Int(nullable: false, identity: true),
                        ComplaintTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ComplaintTypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailId = c.String(),
                        Password = c.String(),
                        StudentId = c.Int(),
                        Name = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Students", "User_Id", c => c.Int());
            AddColumn("dbo.Tickets", "ComplaintTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "User_Id");
            CreateIndex("dbo.Tickets", "ComplaintTypeId");
            AddForeignKey("dbo.Tickets", "ComplaintTypeId", "dbo.ComplaintTypes", "ComplaintTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Tickets", "TicketType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "TicketType", c => c.String());
            DropForeignKey("dbo.Students", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Tickets", "ComplaintTypeId", "dbo.ComplaintTypes");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Tickets", new[] { "ComplaintTypeId" });
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropColumn("dbo.Tickets", "ComplaintTypeId");
            DropColumn("dbo.Students", "User_Id");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.ComplaintTypes");
        }
    }
}
