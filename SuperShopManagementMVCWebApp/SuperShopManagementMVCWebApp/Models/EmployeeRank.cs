using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShopManagementMVCWebApp.Models
{
    public class EmployeeRank
    {
        private ApplicationDbContext _context;

        public EmployeeRank()
        {
            _context = new ApplicationDbContext();
        }
        public int EmployeeRankId { get; set; }
        public string RankName { get; set; }
        public string Salary { get; set; }
        public string Commission { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }


        public bool CheckRankNameExistInDb(string rankName)
        {
            return _context.EmployeeRanks.Any(e => e.RankName == rankName);
        }

        public IEnumerable<SelectListItem> GetEmployeeRanks()
        {
            List<SelectListItem> employeeRanks = _context.EmployeeRanks.AsNoTracking()
                .OrderBy(e => e.EmployeeRankId)
                .Select(e =>
                    new SelectListItem
                    {
                        Value = e.EmployeeRankId.ToString(),
                        Text = e.RankName
                    }
                ).ToList();
            var employeeRankip = new SelectListItem
            {
                Value = "1",
                Text = "Select Rank"

            };
            employeeRanks.Insert(0, employeeRankip);
            return  new SelectList(employeeRanks, "Value", "Text");
        }


    }
}