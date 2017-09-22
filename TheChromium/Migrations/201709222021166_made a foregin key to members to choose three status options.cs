namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeaforeginkeytomemberstochoosethreestatusoptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "StatusId");
            AddForeignKey("dbo.Members", "StatusId", "dbo.MembershipStatus", "id", cascadeDelete: true);
            DropColumn("dbo.Members", "MembershipStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "MembershipStatus", c => c.String());
            DropForeignKey("dbo.Members", "StatusId", "dbo.MembershipStatus");
            DropIndex("dbo.Members", new[] { "StatusId" });
            DropColumn("dbo.Members", "StatusId");
        }
    }
}
