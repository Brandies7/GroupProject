namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingunknownmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Password", c => c.String());
        }
    }
}
