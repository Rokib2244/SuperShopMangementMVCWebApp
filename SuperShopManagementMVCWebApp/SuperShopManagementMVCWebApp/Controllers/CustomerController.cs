using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult SaveNewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveNewCustomer(Customer customer)
        {
            return View();
        }
    }
}