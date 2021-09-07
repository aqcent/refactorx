using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using refactorx.BL.Models;
using refactorx.BL.Models.Request;
using refactorx.BL.Models.Response;
using refactorx.DB;
using refactorx.DB.MSSQL.Entities;
using refactorx.DB.MSSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.BL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        private readonly IScoringService _scoringService;
        private readonly ILogger<ApplicationService> _logger;

        public ApplicationService(
            IApplicationRepository repository,
            IScoringService scoringService,
            ILogger<ApplicationService> logger)
        {
            _repository = repository;
            _scoringService = scoringService;
            _logger = logger;
        }

        public async Task UpdateScoringData(ApplicationEntity application)
        {
            try
            {
                _logger.LogInformation($"[{DateTime.Now}] Start evaluate process..");

                application.ScoringStatus = await _scoringService.Evaluate(application).ConfigureAwait(false);
                application.ScoringDate = DateTime.Now;

                _logger.LogInformation($"[{DateTime.Now}] Evaluate process finished.");

                _repository.Save(application).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError($"[{DateTime.Now}] {e.Message}");
                throw;
            }
        }
    }
}
