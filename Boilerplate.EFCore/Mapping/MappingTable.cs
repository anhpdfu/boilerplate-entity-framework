using Boilerplate.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.EFCore.Mapping
{
    // Auto mapping
    // public class UserMap : BaseEntityConfiguration<User> { }
    public class UserMap : BaseEntityConfiguration<User>
    {
        public UserMap() : this("dbo") { }

        public UserMap(string schema)
        {
            ToTable("UserTable", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName(@"User").HasColumnType("varchar").IsRequired().HasMaxLength(255);
            Property(x => x.Password).HasColumnName(@"Pass").HasColumnType("nvarchar").IsRequired().HasMaxLength(255);
            Property(x => x.FullName).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(255);
        }
    }
}