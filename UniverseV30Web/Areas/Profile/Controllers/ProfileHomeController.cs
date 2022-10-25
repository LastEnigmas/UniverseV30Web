using Core.DTOs.ProfileViewModel;
using Core.Security;
using Core.Services.ProfileSer;
using Data.Model;
using Microsoft.AspNetCore.Authentication;
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
            HttpContext.SignOutAsync();
            return Redirect("Main/MainHome/Index");
        }

        #endregion

        #region PasswordChange

        [Route("ChangePassword")]
        public IActionResult ChangePassword() => View();

        [Route("ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {
            User user = _prifileService.GetUserById(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View(changePassword);
            }
            changePassword.CurrentPassowrd = PasswordHashC.EncodePasswordMd5(changePassword.CurrentPassowrd);
            if(changePassword.CurrentPassowrd != user.Password)
            {
                ViewBag.IsPassword = false;
                ModelState.AddModelError("NewPassword", "Somthings Wrong");
                return View(changePassword);
            }

            changePassword.NewPassword = PasswordHashC.EncodePasswordMd5(changePassword.NewPassword);
            user.Password = changePassword.NewPassword;

            _prifileService.Update(user);
            ViewBag.IsPassword = true;
            HttpContext.SignOutAsync();
            return Redirect("Main/MainHome/Index");
        }
        #endregion
    }
}
