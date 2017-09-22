namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdamembershipmodelmodelformemberstoselecttheircardstatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipStatus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CurrentStats = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipStatus");
        }
    }
}
