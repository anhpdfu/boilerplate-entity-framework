using Boilerplate.EFCore.EFEntityServices;
using Boilerplate.Shared.Entities;
using System.Collections.Generic;

namespace Boilerplate.Business
{
    public interface IUserBusiness : IBaseEntityService<User>
    {
        IEnumerable<User> GetAll();
        void Insert(User user);
    }
}
