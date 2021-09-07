using Microsoft.EntityFrameworkCore;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Repositories
{
    public class BaseRepository<TEntityModel> : IDBRepo<TEntityModel> where TEntityModel : class, IBaseEntity
    {
        private readonly RefactorXContext _context;
        public BaseRepository(RefactorXContext context)
        {
            _context = context;
        }
        public async Task<List<TEntityModel>> Get(IEnumerable<int> keys)
        {
            var _keys = keys?.ToArray() ?? Array.Empty<int>();
            return await DefaultQuery.Where(x => _keys.Contains(x.ID)).ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntityModel> Get(int key)
        {
            return await DefaultQuery.FirstOrDefaultAsync(x => x.ID == key).ConfigureAwait(false);
        }

        public async Task<TResult> CustomQuery<TResult>(Func<RefactorXContext, Task<TResult>> predicate)
        {
            var result = await predicate(_context).ConfigureAwait(false);
            return result;
        }

        public async Task<int> Save(TEntityModel model)
        {
            if (model.ID == default)
                _context.Add(model);
            else
                _context.Update(model);

            _context.SaveChanges();
            return model.ID;
        }

        protected virtual IQueryable<TEntityModel> DefaultQuery => _context.Set<TEntityModel>();
    }
}
