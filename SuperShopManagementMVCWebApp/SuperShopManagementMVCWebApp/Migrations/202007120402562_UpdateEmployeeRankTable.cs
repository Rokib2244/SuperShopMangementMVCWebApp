namespace SuperShopManagementMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeRankTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EmployeeRanks", newName: "tbl_EmployeeRankTable");
            AlterColumn("dbo.tbl_EmployeeRankTable", "RankName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.tbl_EmployeeRankTable", "Salary", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_EmployeeRankTable", "Commission", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_EmployeeRankTable", "Commission", c => c.String());
            AlterColumn("dbo.tbl_EmployeeRankTable", "Salary", c => c.String());
            AlterColumn("dbo.tbl_EmployeeRankTable", "RankName", c => c.String());
            RenameTable(name: "dbo.tbl_EmployeeRankTable", newName: "EmployeeRanks");
        }
    }
}
