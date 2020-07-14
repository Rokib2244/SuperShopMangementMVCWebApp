using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using SuperShopManagementMVCWebApp.Models;
using SuperShopManagementMVCWebApp.ViewModels;

namespace SuperShopManagementMVCWebApp.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;
        public EmployeesController()
        {
                _context = new ApplicationDbContext();
        }
        
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage SaveEmployeeRank(EmployeeRank employeeRank)
        {
            var aEmloyeeRank = new EmployeeRank();
            if (employeeRank == null)
            {
                //ViewBag.Message = "This Employee RankName already Exist";
                //throw new HttpResponseException(HttpStatusCode.c);
                //return msg;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "This is Empty");
                return response;
            }
            if (aEmloyeeRank.CheckRankNameExistInDb(employeeRank.RankName)== true)
            {
                //ViewBag.Message = "This Employee RankName already Exist";
                //throw new HttpResponseException(HttpStatusCode.c);
                //return msg;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "This RankName already Exist");
                return response;
            }
            else
            {
                _context.EmployeeRanks.Add((employeeRank));
                _context.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Saved information successfully");
                return response;
            }

        }
        [System.Web.Http.HttpPost]
        public HttpResponseMessage SaveNewEmployee(EmloyeeFormViewModels emloyeeFormViewModels)
        {
            var aemloyeeFormViewModels = new EmloyeeFormViewModels();
            if (emloyeeFormViewModels == null)
            {
                HttpResponseMessage response =
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Sorry!! This is Null..");
                return response;
            }

            if (aemloyeeFormViewModels.Employee.CheckEmailAddressExist(emloyeeFormViewModels.Employee.EmaiAddress))
            {
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.BadRequest, "This Email Id already Exist");
                return response;
            }
            //if (aemloyeeFormViewModels.Employee.CheckNID_NumberExist(emloyeeFormViewModels.Employee.NID_Number))
            //{
            //    HttpResponseMessage response =
            //        Request.CreateResponse(HttpStatusCode.BadRequest, "This NID Number already Exist");
            //    return response;
            //}
            else
            {
                _context.Employees.Add(emloyeeFormViewModels.Employee);
                _context.SaveChanges();
                HttpResponseMessage response =
                    Request.CreateResponse(HttpStatusCode.OK, "Employee Information Saved Successfully");
                return response;
            }
        }
    }
}
