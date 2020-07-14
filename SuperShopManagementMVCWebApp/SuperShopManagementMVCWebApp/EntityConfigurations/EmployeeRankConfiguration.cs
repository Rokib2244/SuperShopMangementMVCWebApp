using SuperShopManagementMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SuperShopManagementMVCWebApp.EntityConfigurations
{
    public class EmployeeRankConfiguration: EntityTypeConfiguration<EmployeeRank>
    {
        public EmployeeRankConfiguration()
        {
            ToTable("tbl_EmployeeRankTable");
            HasKey(e => e.EmployeeRankId);
            
            Property((e => e.RankName))
                .IsRequired()
                .HasMaxLength(15);
            Property((e => e.Salary))
                .IsRequired();
                
            Property((e => e.Commission))
                .IsRequired();
            HasMany(e => e.Employees)
                .WithRequired(e => e.EmployeeRank)
                .HasForeignKey(e => e.EmployeeRankId);

        }
    }
}