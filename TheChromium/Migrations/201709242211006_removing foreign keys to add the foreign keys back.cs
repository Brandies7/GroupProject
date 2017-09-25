namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingforeignkeystoaddtheforeignkeysback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "StatusId", "dbo.MembershipStatus");
            DropIndex("dbo.Members", new[] { "StatusId" });
            RenameColumn(table: "dbo.Members", name: "Memberid", newName: "MembershipId_Id");
            RenameColumn(table: "dbo.Members", name: "StatusId", newName: "MemberStatus_id");
            RenameIndex(table: "dbo.Members", name: "IX_Memberid", newName: "IX_MembershipId_Id");
            AlterColumn("dbo.Members", "MemberStatus_id", c => c.Int());
            CreateIndex("dbo.Members", "MemberStatus_id");
            AddForeignKey("dbo.Members", "MemberStatus_id", "dbo.MembershipStatus", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "MemberStatus_id", "dbo.MembershipStatus");
            DropIndex("dbo.Members", new[] { "MemberStatus_id" });
            AlterColumn("dbo.Members", "MemberStatus_id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Members", name: "IX_MembershipId_Id", newName: "IX_Memberid");
            RenameColumn(table: "dbo.Members", name: "MemberStatus_id", newName: "StatusId");
            RenameColumn(table: "dbo.Members", name: "MembershipId_Id", newName: "Memberid");
            CreateIndex("dbo.Members", "StatusId");
            AddForeignKey("dbo.Members", "StatusId", "dbo.MembershipStatus", "id", cascadeDelete: true);
        }
    }
}
