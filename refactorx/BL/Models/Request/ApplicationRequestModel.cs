using Newtonsoft.Json;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models.Request
{

    public class CreditDetails
    {
        public int CreditType { get; set; }
        public decimal RequestedAmount { get; set; }
        public string RequestedCurrency { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public string CompanyName { get; set; }
        public string Comment { get; set; }
    }

    public class Applicant
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string CityBirth { get; set; }
        public string AddressBirth { get; set; }
        public string AddressCurrent { get; set; }


        [JsonProperty(Required = Required.Always)]
        public string INN { get; set; }


        [JsonProperty(Required = Required.Always)]
        public string SNILS { get; set; }


        [JsonProperty(Required = Required.Always)]
        public string PassportNum { get; set; }
    }

    public class ApplicationRequestModel
    {
        public string ApplicationNum { get; set; }


        [JsonProperty(Required = Required.Always)]
        public DateTime ApplicationDate { get; set; }


        public string BranchBank { get; set; }
        public string BranchBankAddr { get; set; }


        [JsonProperty(Required = Required.Always)]
        public int CreditManagerId { get; set; }


        [JsonProperty(Required = Required.Always)]
        public Applicant Applicant { get; set; }


        [JsonProperty(Required = Required.Always)]
        public CreditDetails RequestedCredit { get; set; }


        public static implicit operator ApplicationEntity(ApplicationRequestModel source)
        {
            var result = new ApplicationEntity()
            {
                ApplicationNum = source.ApplicationNum,
                ApplicationDate = source.ApplicationDate,

                BranchBank = new BranchBankEntity()
                {
                    Address = source.BranchBankAddr,
                    Name = source.BranchBank
                },

                CreditManagerID = source.CreditManagerId,

                Applicant = new ApplicantEntity()
                {
                    AddressBirth = source.Applicant.AddressBirth,
                    AddressCurrent = source.Applicant.AddressCurrent,
                    CityBirth = source.Applicant.CityBirth,
                    DateBirth = source.Applicant.DateBirth,
                    FirstName = source.Applicant.FirstName,
                    INN = source.Applicant.INN,
                    LastName = source.Applicant.LastName,
                    MiddleName = source.Applicant.MiddleName,
                    PassportNum = source.Applicant.PassportNum,
                    SNILS = source.Applicant.SNILS
                },

                CreditType = source.RequestedCredit.CreditType,
                RequestedAmount = source.RequestedCredit.RequestedAmount,
                
                RequestedCurrency = new CurrencyEntity()
                {
                    Title = source.RequestedCredit.RequestedCurrency
                },

                AnnualSalary = source.RequestedCredit.AnnualSalary,
                MonthlySalary = source.RequestedCredit.MonthlySalary,
                CompanyName = source.RequestedCredit.CompanyName,
                Comment = source.RequestedCredit.Comment
            };

            return result;
        }
    }
}
