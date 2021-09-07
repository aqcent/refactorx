using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models
{
    public enum CurrencyCode
    {
        Rur = 1,
        Usd = 2
    }
    public class Currency
    {
        public int ID { get; set; }
        public CurrencyCode Code => (CurrencyCode)ID;
        public string Title { get; set; }
    }
}
