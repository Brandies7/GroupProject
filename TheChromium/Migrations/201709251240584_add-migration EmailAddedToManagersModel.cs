namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationEmailAddedToManagersModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Managers", "Email");
        }
    }
}
