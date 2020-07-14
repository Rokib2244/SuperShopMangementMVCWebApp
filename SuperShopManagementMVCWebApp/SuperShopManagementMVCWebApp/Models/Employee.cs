using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementMVCWebApp.Models
{
    public class Employee
    {
        private ApplicationDbContext _context;

        public Employee()
        {
            _context = new ApplicationDbContext();
        }
        public int EmployeeId { get; set; }

        //[Required(ErrorMessage ="Please Enter Employee Name")]
        public string EmloyeeName { get; set; }
        //[Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public string EmaiAddress { get; set; }
        public string Gender { get; set; }

        //[Required(ErrorMessage = "Please Enter Birthdate")]

        public DateTime Birthdate { get; set; }
        

        //[Required(ErrorMessage = "Please Enter a Contact Number")]
        //[DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
        //[Required(ErrorMessage = "Please Enter NID Number")]
        //[DisplayName("NID Number")]
        public string NID_Number { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
        public  virtual  EmployeeRank EmployeeRank { get; set; }
        public int EmployeeRankId { get; set; }

        public bool CheckEmailAddressExist(string emailAddress)
        {
            return _context.Employees.Any(e => e.EmaiAddress == emailAddress);
        }
        public bool CheckNID_NumberExist(string nid_number)
        {
            return _context.Employees.Any(e => e.NID_Number == nid_number);
        }



    }
}