using Boilerplate.EFCore.Data;
using Boilerplate.EFCore.EFEntityServices;
using Boilerplate.Shared.Entities;
using System.Collections.Generic;

namespace Boilerplate.Business
{
    public class UserBusiness : BaseEntityService<User>, IUserBusiness
    {
        public UserBusiness(IDataRepository<User> dataRepository) : base(dataRepository)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return Repository.Table;
        }

        public void Insert(User user)
        {
            Repository.Insert(user);
        }
    }
}
