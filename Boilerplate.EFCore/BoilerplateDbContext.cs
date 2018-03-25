using Boilerplate.EFCore.Mapping;
using Boilerplate.Shared.Entities;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;

namespace Boilerplate.EFCore
{
    public class BoilerplateDbContext : DbContext, IBoilerplateDbContext
    {
        #region Ctors

        public BoilerplateDbContext()
            : base("Name=Default")
        {
            Configuration.LazyLoadingEnabled = false;

            //Database.SetInitializer<ViettelIdcContext>(null);
        }

        public BoilerplateDbContext(string connectionString)
            : base(connectionString) { }

        public BoilerplateDbContext(string connectionString, DbCompiledModel model)
            : base(connectionString, model) { }

        public BoilerplateDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        public BoilerplateDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection) { }

        #endregion

        public DbRawSqlQuery<T> SqlQuery<T>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<T>(sqlQuery, parameters);
        }

        public void ExecuteSql(TransactionalBehavior? transactionalBehavior, string sqlQuery,
            params object[] parameters)
        {
            if (transactionalBehavior.HasValue)
                Database.ExecuteSqlCommand(transactionalBehavior.Value, sqlQuery, parameters);
            else
                Database.ExecuteSqlCommand(sqlQuery, parameters);
        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public bool DatabaseExists()
        {
            return Database.Exists();
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            if (sqlValue is INullable nullableValue)
                return nullableValue.IsNull;
            return sqlValue == null || sqlValue == DBNull.Value;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = typeof(BoilerplateDbContext).Assembly.GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            //modelBuilder.Entity<User>().ToTable("User");

            base.OnModelCreating(modelBuilder);
        }
    }
}
