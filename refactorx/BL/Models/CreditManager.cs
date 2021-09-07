using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Models
{
    public class CreditManager : Person
    {
        public BranchBank BranchBank { get; set; }
    }
}
