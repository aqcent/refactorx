using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Entities
{
    public class CreditManagerEntity : PersonEntity
    {
        public int BranchBankID { get; set; }
        public virtual BranchBankEntity BranchBank { get; set; }
    }
}
