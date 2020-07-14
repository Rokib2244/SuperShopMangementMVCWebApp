using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.EntityConfigurations
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {

            

            Property(d => d.DepartmentCode)
                .IsRequired()
                .HasMaxLength(10);
            
                Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}