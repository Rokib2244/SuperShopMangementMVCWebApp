using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("tbl_Employee");
            HasKey(e => e.EmployeeId);

            Property(e => e.EmloyeeName)
            .IsRequired()
            .HasMaxLength(15);


            Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(30);


            Property(e => e.EmaiAddress)
            .IsRequired()
            .HasMaxLength(20);


            Property(e => e.Gender)
            .IsRequired();


            Property(e => e.Birthdate)
            .IsRequired();



            Property(e => e.ContactNumber)
            .IsRequired()
            .HasMaxLength(15);


            Property(e => e.NID_Number)
            .IsRequired()
            .HasMaxLength(20);


            Property(e => e.DepartmentId)
            .IsRequired();

            Property(e => e.EmployeeRankId)
                .IsRequired();



            HasRequired(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .WillCascadeOnDelete(false);

           
                

            //base.OnModelCreating(modelBuilder);

        }
    }
}