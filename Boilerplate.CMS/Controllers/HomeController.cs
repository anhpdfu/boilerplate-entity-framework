using Boilerplate.Business;
using Boilerplate.EFCore.EFComplexServices;
using Boilerplate.Shared.Entities;
using System.Web.Mvc;

namespace Boilerplate.CMS.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IComplexUserServices _userServices;

        public HomeController(IUserBusiness userBusiness, IComplexUserServices userServices)
        {
            _userBusiness = userBusiness;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            var user = new User
            {
                UserName = "hoangpm",
                FullName = "Minh Hoàng",
                Password = "123456"
            };

            _userBusiness.Insert(user);

            return View();
        }

        public ActionResult About()
        {
            _userServices.UpdateUserName(3, "MinhHoang");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}