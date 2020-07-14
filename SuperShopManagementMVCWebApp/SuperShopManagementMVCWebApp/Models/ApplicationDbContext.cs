using SuperShopManagementMVCWebApp.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperShopManagementMVCWebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public  DbSet<EmployeeRank> EmployeeRanks { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EmployeeRankConfiguration());

        }
    }
}