using Boilerplate.Business;
using Boilerplate.Shared.Entities;
using System.Collections.Generic;

namespace Boilerplate.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        public IEnumerable<User> Get()
        {
            return _userBusiness.GetAll();
        }
    }
}