using refactorx.BL.Models;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Services
{
    public interface IScoringService
    {
        Task<bool> Evaluate(ApplicationEntity application);
    }
}
