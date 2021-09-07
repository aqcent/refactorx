using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using refactorx.BL.Services;

namespace refactorx.Controllers
{
    /// <summary>
    /// Описание контроллера Scoring
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoringController : ControllerBase
    {
        private readonly IScoringService _service;
        private readonly ILogger<ScoringController> _logger;

        public ScoringController(
            ILogger<ScoringController> logger,
            IScoringService service
            )
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Мок сервиса скоринга, который возвращает решение по заявке
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Evaluate()
        {
            var result = await _service.Evaluate(null).ConfigureAwait(false);

            return Ok(new { ScoringStatus = result });
        }
    }
}