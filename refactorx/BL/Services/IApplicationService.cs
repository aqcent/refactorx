using refactorx.BL.Models;
using refactorx.BL.Models.Response;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Services
{
    public interface IApplicationService
    {
        Task UpdateScoringData(ApplicationEntity application);
    }
}
