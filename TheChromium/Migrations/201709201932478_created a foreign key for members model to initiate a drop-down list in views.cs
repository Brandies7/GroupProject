namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdaforeignkeyformembersmodeltoinitiateadropdownlistinviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Memberid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Members", "Memberid");
            AddForeignKey("dbo.Members", "Memberid", "dbo.AspNetRoles", "Id");
            DropColumn("dbo.Members", "MembershipType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "MembershipType", c => c.String());
            DropForeignKey("dbo.Members", "Memberid", "dbo.AspNetRoles");
            DropIndex("dbo.Members", new[] { "Memberid" });
            DropColumn("dbo.Members", "Memberid");
        }
    }
}
