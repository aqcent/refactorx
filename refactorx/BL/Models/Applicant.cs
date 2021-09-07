using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models
{
    public class Applicant : Person
    {
        public string CityBirth {get;set;}
        public string AddressBirth {get;set;}
        public string AddressCurrent {get;set;}
        public string INN {get;set;}
        public string SNILS {get;set;}
        public string PassportNum {get;set;}
    }
}
