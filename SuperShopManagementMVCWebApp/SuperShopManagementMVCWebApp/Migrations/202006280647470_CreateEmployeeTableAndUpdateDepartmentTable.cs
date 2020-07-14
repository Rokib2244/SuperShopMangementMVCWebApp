namespace SuperShopManagementMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmployeeTableAndUpdateDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmloyeeName = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 30),
                        EmaiAddress = c.String(nullable: false, maxLength: 20),
                        Gender = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        ContactNumber = c.String(nullable: false, maxLength: 15),
                        NID_Number = c.String(nullable: false, maxLength: 20),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Employee", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.tbl_Employee", new[] { "DepartmentId" });
            DropTable("dbo.tbl_Employee");
        }
    }
}
