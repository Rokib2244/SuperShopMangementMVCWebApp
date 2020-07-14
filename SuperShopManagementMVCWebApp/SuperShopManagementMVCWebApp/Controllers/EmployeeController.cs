using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using SuperShopManagementMVCWebApp.Models;
using SuperShopManagementMVCWebApp.ViewModels;

namespace SuperShopManagementMVCWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            

            _context.Dispose();
        }
        public ActionResult SaveEmployeeRank()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveEmployeeRank(EmployeeRank employeeRank)
        {

            return View();
        }
        public ActionResult SaveNewEmployee()
        {
            var departments = new  Department();
            var employeeRanks = new EmployeeRank();
            var emloyeeFormViewModels = new EmloyeeFormViewModels
            {
                Employee = new Employee(),
                Departments = departments.GetDepartments(),
                EmployeeRanks = employeeRanks.GetEmployeeRanks()
            };




            return View(emloyeeFormViewModels);
        }
        [HttpPost]
        public ActionResult SaveNewEmployee(EmloyeeFormViewModels emloyeeFormViewModels)
        {
            _context.Employees.Add(emloyeeFormViewModels.Employee);
            _context.SaveChanges();
            return View();
        }
        //public JsonResult DepartmentList()
        //{
        //    var departments = _context.Departments.ToList();
        //    return Json(departments, JsonRequestBehavior.AllowGet);

        //}

    }
}