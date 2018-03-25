using Boilerplate.EFCore.Data;
using Boilerplate.EFCore.EFEntityServices;
using Boilerplate.Shared.Entities;

namespace Boilerplate.Business
{
    public class UserBusiness : BaseEntityService<User>, IUserBusiness
    {
        public UserBusiness(IDataRepository<User> dataRepository) : base(dataRepository)
        {
        }

        public void Insert(User user)
        {
            Repository.Insert(user);
        }
    }
}
