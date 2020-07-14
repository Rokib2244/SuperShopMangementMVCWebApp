namespace SuperShopManagementMVCWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 10),
                        DepartmentName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
