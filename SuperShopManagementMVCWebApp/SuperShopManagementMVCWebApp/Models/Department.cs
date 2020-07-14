using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementMVCWebApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        private ApplicationDbContext _context;
        public Department()
        {
            _context = new ApplicationDbContext();
        }
        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}
        public bool CheckDepartmentCodeDoesExist(string departmentCode)
        {
            return _context.Departments.Any(d => d.DepartmentCode == departmentCode);
        }
        public bool CheckDepartmentNameDoesExist(string departmentName)
        {
            return _context.Departments.Any(d => d.DepartmentName == departmentName);
        }
        public IEnumerable<SelectListItem> GetDepartments()
        {
            List<SelectListItem> departments = _context.Departments.AsNoTracking()
                .OrderBy(d => d.DepartmentName)
                .Select(d =>
                new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                }
                ).ToList();
            var departmentip = new SelectListItem
            {
                Value = "0",
                Text = "Select Department"
            };
            departments.Insert(0, departmentip);
            return new SelectList(departments, "Value", "Text");
        }

    }
}