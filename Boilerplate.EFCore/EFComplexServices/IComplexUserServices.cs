using Boilerplate.Shared.Entities;

namespace Boilerplate.EFCore.EFComplexServices
{
    public interface IComplexUserServices
    {
        int UpdateUserName(int userId, string userName);
    }
}
