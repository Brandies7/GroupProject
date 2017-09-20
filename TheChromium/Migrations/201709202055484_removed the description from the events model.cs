namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedthedescriptionfromtheeventsmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Description", c => c.String());
        }
    }
}
