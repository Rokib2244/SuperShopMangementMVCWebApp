using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private ApplicationDbContext _context;
        public DepartmentController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult CreateDepartment()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult CreateDepartment(Department department)
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateDepartment", department);
            }

            if (_context.Departments.Any(c => c.DepartmentCode == department.DepartmentCode))
            {
                ViewBag.Message = "This Department Code  already Exist";
                return View("CreateDepartment", department);

            }


            if (_context.Departments.Any(c => c.DepartmentName == department.DepartmentName))
            {
                ViewBag.Message = "This Department Name  already Exist";
                return View("CreateDepartment", department);
            }



            else
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                ViewBag.Message = "Department Saved Successfully";
            }
            //_context.Departments.Add(department);
            //_context.SaveChanges();
            //ViewBag.Message = "Department Saved Successfully";


            //if (departmentsInDb == null)
            //{
            //    _context.Departments.Add(department);
            //    _context.SaveChanges();
            //    ViewBag.Message = "Department Saved Successfully";
            //}
            //else
            //{
            //    foreach (var departments in departmentsInDb)
            //    {
            //        if (departments.DepartmentCode == department.DepartmentCode || departments.DepartmentName == department.DepartmentName)
            //        {
            //            ViewBag.Message = "This Department Code or Department Name already Exist";
            //        }
            //        else
            //        {
            //            _context.Departments.Add(department);
            //            _context.SaveChanges();
            //            ViewBag.Message = "Department Saved Successfully";
            //        }
            //    }
            //}    


            return View();
        }
        public ActionResult ShowAllDepaartment()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
    }
}