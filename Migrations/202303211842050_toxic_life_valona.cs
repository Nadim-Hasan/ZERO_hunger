namespace ZERO_hunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class toxic_life_valona : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonationDetails", "EmpId", "dbo.Employees");
            DropIndex("dbo.DonationDetails", new[] { "EmpId" });
            RenameColumn(table: "dbo.Donations", name: "ResId", newName: "Restaurant_Id");
            RenameIndex(table: "dbo.Donations", name: "IX_ResId", newName: "IX_Restaurant_Id");
            AddColumn("dbo.Donations", "RId", c => c.Int(nullable: false));
            AlterColumn("dbo.DonationDetails", "EmpId", c => c.Int(nullable: false));
            CreateIndex("dbo.DonationDetails", "EmpId");
            AddForeignKey("dbo.DonationDetails", "EmpId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonationDetails", "EmpId", "dbo.Employees");
            DropIndex("dbo.DonationDetails", new[] { "EmpId" });
            AlterColumn("dbo.DonationDetails", "EmpId", c => c.Int());
            DropColumn("dbo.Donations", "RId");
            RenameIndex(table: "dbo.Donations", name: "IX_Restaurant_Id", newName: "IX_ResId");
            RenameColumn(table: "dbo.Donations", name: "Restaurant_Id", newName: "ResId");
            CreateIndex("dbo.DonationDetails", "EmpId");
            AddForeignKey("dbo.DonationDetails", "EmpId", "dbo.Employees", "Id");
        }
    }
}
