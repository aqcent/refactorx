using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Entities
{
    public class CurrencyEntity : IBaseEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
