namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changednameofforeignkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Members", name: "StatusId", newName: "MembershipStatusId");
            RenameIndex(table: "dbo.Members", name: "IX_StatusId", newName: "IX_MembershipStatusId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Members", name: "IX_MembershipStatusId", newName: "IX_StatusId");
            RenameColumn(table: "dbo.Members", name: "MembershipStatusId", newName: "StatusId");
        }
    }
}
