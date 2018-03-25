using Boilerplate.Shared.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Boilerplate.EFCore
{
    public interface IBoilerplateDbContext
    {
        Database Database { get; }
        IDbSet<T> Set<T>() where T : BaseEntity;
        DbRawSqlQuery<T> SqlQuery<T>(string sqlQuery, params object[] parameters);
        void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery, params object[] parameters);
        int SaveChanges();
        bool DatabaseExists();
        bool IsSqlParameterNull(SqlParameter param);
    }
}
