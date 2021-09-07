using Microsoft.Extensions.Logging;
using refactorx.BL.Models;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace refactorx.BL.Services
{
    public class ScoringService : IScoringService
    {
        private readonly ILogger<ScoringService> _logger;
        private readonly int delaySec = 5;

        public ScoringService(ILogger<ScoringService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> Evaluate(ApplicationEntity application)
        {
            _logger.LogInformation($"   start evaluate process {DateTime.Now.Second}");

            Thread.Sleep(delaySec * 1000);

            _logger.LogInformation($"   finish evaluate process {DateTime.Now.Second}");

            return new Random().Next(10) < 5 ? true : false;
        }
    }
}
