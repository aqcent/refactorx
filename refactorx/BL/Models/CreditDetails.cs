using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models
{
    public class CreditDetails
    {
        public int CreditType { get; set; }
        public int RequestedAmount { get; set; }
        public Currency RequestedCurrency { get; set; }
        public int AnnualSalary { get; set; }
        public int MonthlySalary { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }
    }
}
