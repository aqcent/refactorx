using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models
{
    public class Application
    {
        public int ID { get; set; }
        public string ApplicationNum { get; set; }
        public DateTime ApplicationDate { get; set; }
        public BranchBank BranchBank { get; set; }
        public CreditManager CreditManager { get; set; }
        public Applicant Applicant { get; set; }
        public CreditDetails RequestedCredit { get; set; }
    }
}
