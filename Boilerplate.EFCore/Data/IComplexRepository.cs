using System.Collections.Generic;
using System.Data.Entity;

namespace Boilerplate.EFCore.Data
{
    public interface IComplexRepository
    {
        List<T> SqlQuery<T>(string sqlQuery, params object[] parameters);
        void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery, params object[] parameters);
    }
}
