using Boilerplate.EFCore.EFEntityServices;
using Boilerplate.Shared.Entities;

namespace Boilerplate.Business
{
    public interface IUserBusiness : IBaseEntityService<User>
    {
        void Insert(User user);
    }
}
