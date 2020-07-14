using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.Controllers.Api
{
    public class DepartmentsController : ApiController
    {
        private ApplicationDbContext _context;
        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
        public Department GetDepartment(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.DepartmentId == id);
            if (department == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return department;
        }
        [HttpPost]
        public Department CreateDepartment(Department department)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public void UpdateDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var departmentInDb = _context.Departments.SingleOrDefault(c => c.DepartmentId == id);
            if (departmentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            departmentInDb.DepartmentCode = department.DepartmentCode;
            departmentInDb.DepartmentName = department.DepartmentName;
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteDepartment(int id)
        {
            var departmentInDb = _context.Departments.SingleOrDefault(c => c.DepartmentId == id);
            if (departmentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Departments.Remove(departmentInDb);
            _context.SaveChanges();
        }
    }
}
