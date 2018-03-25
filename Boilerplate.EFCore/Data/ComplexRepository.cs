using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Boilerplate.EFCore.Data
{
    public class ComplexRepository : IComplexRepository
    {
        private readonly IBoilerplateDbContext _dbContext;

        public ComplexRepository(IBoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> SqlQuery<T>(string sqlQuery, params object[] parameters)
        {
            return _dbContext.SqlQuery<T>(sqlQuery, parameters).ToList();
        }

        public void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery, params object[] parameters)
        {
            _dbContext.ExecuteSql(transactionalBehavior, sqlQuery, parameters);
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            return _dbContext.IsSqlParameterNull(param);
        }
    }
}
