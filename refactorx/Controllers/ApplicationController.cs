using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using refactorx.BL.Models.Request;
using refactorx.BL.Models.Response;
using refactorx.BL.Services;
using refactorx.DB;
using refactorx.DB.MSSQL;
using refactorx.DB.MSSQL.Entities;
using refactorx.DB.MSSQL.Repositories;

namespace refactorx.Controllers
{
    /// <summary>
    /// Описание контроллера Application
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationService _service;
        private readonly IApplicationRepository _repository;

        public ApplicationController(
            ILogger<ApplicationController> logger,
            IApplicationService service,
            IApplicationRepository repository)
        {
            _logger = logger;
            _service = service;
            _repository = repository;
        }

        /// <summary>
        /// Принимает заявку в формате json. Возвращает уникальный номер и Id принятой заявки в формате json.
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationRequestModel application)
        {
            try
            {
                var entity = (ApplicationEntity)application;
                var id = await _repository.Save(entity).ConfigureAwait(false);

                _logger.LogInformation($"[{DateTime.Now}] Save completed successfully. ID = {id}");

                _service.UpdateScoringData(entity).ConfigureAwait(false);

                return Ok(new { entity.ID, entity.ApplicationNum });
            }
            catch (Exception e)
            {
                _logger.LogError($"[{DateTime.Now}] {e.Message}");
                throw;
            }
        }

        /// <summary>
        /// Возвращает результат рассмотрения заявки с некоторыми деталями по заявке по ее номеру в формате json (статус одобрения кредита)
        /// </summary>
        /// <param name="num">Номер заявки (ApplicationNum)</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Status(string num)
        {
            var result = await _repository.GetByNumber(num).ConfigureAwait(false);
            return Ok((ApplicationResponseModel)result);
        }
    }
}
