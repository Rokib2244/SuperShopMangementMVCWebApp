namespace SuperShopManagementMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeTableAndAddEmployeeRankTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeRanks",
                c => new
                    {
                        EmployeeRankId = c.Int(nullable: false, identity: true),
                        RankName = c.String(),
                        Salary = c.String(),
                        Commission = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeRankId);
            
            AddColumn("dbo.tbl_Employee", "EmployeeRankId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_Employee", "EmployeeRankId");
            AddForeignKey("dbo.tbl_Employee", "EmployeeRankId", "dbo.EmployeeRanks", "EmployeeRankId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Employee", "EmployeeRankId", "dbo.EmployeeRanks");
            DropIndex("dbo.tbl_Employee", new[] { "EmployeeRankId" });
            DropColumn("dbo.tbl_Employee", "EmployeeRankId");
            DropTable("dbo.EmployeeRanks");
        }
    }
}
