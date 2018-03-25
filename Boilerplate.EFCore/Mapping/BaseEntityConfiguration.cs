using Boilerplate.Shared.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Boilerplate.EFCore.Mapping
{
    public abstract class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseEntityConfiguration()
        {
            ToTable(TableName);
        }

        protected virtual string TableName => typeof(T).Name;
    }
}