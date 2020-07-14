using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult SaveProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            return View();
        }
    }
}