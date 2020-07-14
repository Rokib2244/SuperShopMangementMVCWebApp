using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperShopManagementMVCWebApp.Models;

namespace SuperShopManagementMVCWebApp.ViewModels
{
    public class EmloyeeFormViewModels
    {
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> EmployeeRanks { get; set; }
        public int SelectedDepartmentId { get; set; }

        public Employee Employee { get; set; }

    }
}