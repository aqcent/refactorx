using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Entities
{
    public class ApplicationEntity : IBaseEntity
    {
        public int ID { get; set; }
        public string ApplicationNum { get; set; }
        public DateTime ApplicationDate { get; set; }

        public int BranchBankID { get; set; }
        public virtual BranchBankEntity BranchBank { get; set; }

        public int CreditManagerID { get; set; }
        //public virtual CreditManagerEntity CreditManager { get; set; }

        public int ApplicantID { get; set; }
        public virtual ApplicantEntity Applicant { get; set; }


        //RequestedCredit
        public int CreditType { get; set; }
        public decimal RequestedAmount { get; set; }

        public int RequestedCurrencyID { get; set; }
        public virtual CurrencyEntity RequestedCurrency { get; set; }
        

        public decimal AnnualSalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }

        public bool? ScoringStatus { get; set; }
        public DateTime? ScoringDate { get; set; }
    }
}
