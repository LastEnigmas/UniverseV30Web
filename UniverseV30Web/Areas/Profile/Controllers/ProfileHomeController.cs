using Core.DTOs.ProfileViewModel;
using Core.Services.ProfileSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseV30Web.Areas.Profile.Controllers
{
    [Area("Profile")]
    [Authorize]
    public class ProfileHomeController : Controller
    {
        private readonly IProfileService _prifileService;
        public ProfileHomeController( IProfileService profile)
        {
            _prifileService = profile;
        }
        public IActionResult Index() => View();

        #region Universe

        #endregion

        #region Info Universe

        [Route("InfoUniverse")]
        public IActionResult InfoUniverse()
        {
            InfoUserViewModel infoUser = _prifileService.GetUserInfo(User.Identity.Name);
            return View(infoUser);
        }


        [Route("InfoUniverse")]
        [HttpPost]
        public IActionResult InfoUniverse(InfoUserViewModel infoUser)
        {
            ViewBag.IsCheack = _prifileService.CheackEdit(infoUser);
            return View(infoUser);
        }

        #endregion
    }
}
