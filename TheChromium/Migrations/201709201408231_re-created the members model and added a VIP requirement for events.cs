namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreatedthemembersmodelandaddedaVIPrequirementforevents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MembershipType = c.String(),
                        MembershipStatus = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Events", "VIPRequired", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "VIPRequired");
            DropTable("dbo.Members");
        }
    }
}
