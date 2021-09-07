using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL.Repositories
{
    public interface IApplicationRepository
    {
        public Task<List<ApplicationEntity>> Get(IEnumerable<int> keys);
        public Task<ApplicationEntity> Get(int key);
        public Task<ApplicationEntity> GetByNumber(string num);
        public Task<TResult> CustomQuery<TResult>(Func<RefactorXContext, Task<TResult>> predicate);
        public Task<int> Save(ApplicationEntity model);
    }
}
