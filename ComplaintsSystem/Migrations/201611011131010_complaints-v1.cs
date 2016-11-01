namespace ComplaintsSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complaintsv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ComplaintTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ComplaintTypeId");
            AddForeignKey("dbo.Tickets", "ComplaintTypeId", "dbo.ComplaintTypes", "ComplaintTypeId", cascadeDelete: true);
            DropColumn("dbo.Tickets", "TicketType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "TicketType", c => c.String());
            DropForeignKey("dbo.Tickets", "ComplaintTypeId", "dbo.ComplaintTypes");
            DropIndex("dbo.Tickets", new[] { "ComplaintTypeId" });
            DropColumn("dbo.Tickets", "ComplaintTypeId");
        }
    }
}
