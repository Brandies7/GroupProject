namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddriversid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "DriversNumber", c => c.String());
         
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "DriverID", c => c.String());
            DropColumn("dbo.Members", "DriversNumber");
        }
    }
}
