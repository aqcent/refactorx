using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using refactorx.BL.Models;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Repositories
{
    public class ApplicationRepository : BaseRepository<ApplicationEntity>, IApplicationRepository
    {
        private readonly RefactorXContext _context;
        private readonly ILogger<ApplicationRepository> _logger;

        public ApplicationRepository(RefactorXContext context, ILogger<ApplicationRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        protected override IQueryable<ApplicationEntity> DefaultQuery => _context.Set<ApplicationEntity>()
                                                                                 .Include(x => x.Applicant)
                                                                                 .Include(x => x.BranchBank)
                                                                                 .Include(x => x.RequestedCurrency);


        public new async Task<int> Save(ApplicationEntity entity)
        {
            try
            {
                var id = await base.Save(entity).ConfigureAwait(false);
                _logger.LogInformation($"[{DateTime.Now}] Save to DB completed successfully. ID = {id}");
                return id;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ApplicationEntity> GetByNumber(string num)
        {
            var result = await DefaultQuery.FirstOrDefaultAsync(x => x.ApplicationNum == num).ConfigureAwait(false);

            return result;
        }
    }
}
