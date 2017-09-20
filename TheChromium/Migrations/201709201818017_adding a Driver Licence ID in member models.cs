namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingaDriverLicenceIDinmembermodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "DriverID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "DriverID");
        }
    }
}
