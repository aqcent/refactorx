using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models.Response
{
    public class Applicant
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class CreditDetails
    {
        public int CreditType { get; set; }
        public decimal RequestedAmount { get; set; }
        public string RequestedCurrency { get; set; }
    }

    public class ApplicationResponseModel
    {
        public int Id { get; set; }
        public string ApplicationNum { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string BranchBank { get; set; }
        public string BranchBankAddr { get; set; }
        public int CreditManagerId { get; set; }
        public Applicant Applicant { get; set; }
        public CreditDetails RequestedCredit { get; set; }

        public bool? ScoringStatus { get; set; }
        public DateTime? ScoringDate { get; set; }


        public static explicit operator ApplicationResponseModel(ApplicationEntity source)
        {
            if (source == null) return null;

            var result = new ApplicationResponseModel()
            {
                Id = source.ID,
                ApplicationNum = source.ApplicationNum,
                ApplicationDate = source.ApplicationDate,
                BranchBank = source.BranchBank.Name,
                BranchBankAddr = source.BranchBank.Address,
                CreditManagerId = source.CreditManagerID,
                Applicant = new Applicant()
                {
                    FirstName = source.Applicant.FirstName,
                    LastName = source.Applicant.LastName,
                    MiddleName = source.Applicant.MiddleName
                },
                RequestedCredit = new CreditDetails()
                {
                    CreditType = source.CreditType,
                    RequestedAmount = source.RequestedAmount,
                    RequestedCurrency = source.RequestedCurrency.Title
                },
                ScoringDate = source.ScoringDate,
                ScoringStatus = source.ScoringStatus
            };

            return result;
        }
    }
}
