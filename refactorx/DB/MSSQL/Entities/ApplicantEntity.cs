using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Entities
{
    public class ApplicantEntity : PersonEntity
    {
        public string CityBirth { get; set; }
        public string AddressBirth { get; set; }
        public string AddressCurrent { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public string PassportNum { get; set; }
    }
}
