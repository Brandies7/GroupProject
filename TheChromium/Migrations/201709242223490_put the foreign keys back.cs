namespace TheChromium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class puttheforeignkeysback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "MemberStatus_id", "dbo.MembershipStatus");
            DropIndex("dbo.Members", new[] { "MemberStatus_id" });
            RenameColumn(table: "dbo.Members", name: "MembershipId_Id", newName: "Memberid");
            RenameColumn(table: "dbo.Members", name: "MemberStatus_id", newName: "StatusId");
            RenameIndex(table: "dbo.Members", name: "IX_MembershipId_Id", newName: "IX_Memberid");
            AlterColumn("dbo.Members", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "StatusId");
            AddForeignKey("dbo.Members", "StatusId", "dbo.MembershipStatus", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "StatusId", "dbo.MembershipStatus");
            DropIndex("dbo.Members", new[] { "StatusId" });
            AlterColumn("dbo.Members", "StatusId", c => c.Int());
            RenameIndex(table: "dbo.Members", name: "IX_Memberid", newName: "IX_MembershipId_Id");
            RenameColumn(table: "dbo.Members", name: "StatusId", newName: "MemberStatus_id");
            RenameColumn(table: "dbo.Members", name: "Memberid", newName: "MembershipId_Id");
            CreateIndex("dbo.Members", "MemberStatus_id");
            AddForeignKey("dbo.Members", "MemberStatus_id", "dbo.MembershipStatus", "id");
        }
    }
}
