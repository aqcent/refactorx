using refactorx.DB.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB
{
    public interface IDBRepo<TEntityModel>
    {
        public Task<List<TEntityModel>> Get(IEnumerable<int> keys);
        public Task<TEntityModel> Get(int key);
        public Task<TResult> CustomQuery<TResult>(Func<RefactorXContext, Task<TResult>> predicate);
        public Task<int> Save(TEntityModel model);
    }
}
