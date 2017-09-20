namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replacedVIPrequirementswithamembershiprequirement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Memberid", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "Location", c => c.String());
            CreateIndex("dbo.Events", "Memberid");
            AddForeignKey("dbo.Events", "Memberid", "dbo.AspNetRoles", "Id");
            DropColumn("dbo.Events", "VIPRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "VIPRequired", c => c.String());
            DropForeignKey("dbo.Events", "Memberid", "dbo.AspNetRoles");
            DropIndex("dbo.Events", new[] { "Memberid" });
            DropColumn("dbo.Events", "Location");
            DropColumn("dbo.Events", "Memberid");
        }
    }
}
