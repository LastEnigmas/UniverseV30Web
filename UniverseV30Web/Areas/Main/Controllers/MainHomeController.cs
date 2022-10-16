using Core.Convertor;
using Core.DTOs.MainViewModels;
using Core.Generator;
using Core.Security;
using Core.Sender;
using Core.Services.MainSer;
using Data.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Core.Convertor.ViewToString;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient.Server;

namespace UniverseV30Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class MainHomeController : Controller
    {
        private readonly IMainService _mainService;
        private readonly IViewRenderService _render;
        public MainHomeController( IMainService mainService , IViewRenderService render )
        {
            _mainService = mainService;
            _render = render;
        }
        public IActionResult Index() => View();

        [Authorize]
        public IActionResult Hello() => View();

        #region SignUp

        [Route("SignUp")]
        public IActionResult SignUp() => View();

        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(SignUpViewModel signUp )
        {
            if(!ModelState.IsValid)
            {
                return View(signUp);
            }

            if (_mainService.IsEmail(FixText.FixTexts(signUp.Email)))
            {
                ModelState.AddModelError("Email", "Is Exist");
                return View(signUp);
            }

            if (_mainService.IsUsername(FixText.FixTexts(signUp.Username)))
            {
                ModelState.AddModelError("Username", "Is Exist");
                return View(signUp);
            }

            User user = new User()
            {
                Username = signUp.Username,
                Email = signUp.Email,
                Password = PasswordHashC.EncodePasswordMd5(signUp.Password),
                Picture = "",
                ActiveCode = ActiveCodeGen.GenerateCode(),
                IsActive = false,
                PictureTitle = "defult.jpg",
            };

            _mainService.Add(user);                                
            string Body = _render.RenderToStringAsync("registerView", user);
            EmailSenders.Send(user.Email, "Register", Body);

            return View();
        }

        #endregion

        #region Register

        public IActionResult Register(string id)
        {
            RegisterViewModel register = _mainService.Register(id);

            if(register != null)
            {
                ViewBag.IsRegister = true;
                return View(register);
            }

            ViewBag.IsRegister = false;
            return View();
        }

        #endregion

        #region SignIn

        [Route("SignIn")]
        public IActionResult SignIn() => View();

        [Route("SignIn")]
        [HttpPost]
        public IActionResult SignIn(SignInViewModel signIn)
        {
            if (!ModelState.IsValid)
            {
                return View(signIn);
            }

            User user =_mainService.SignInUser(signIn);
            if(user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name , user.Username),
                        new Claim(ClaimTypes.Email, user.Email),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = signIn.RemmemberMe,
                    };

                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSignIn = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("UsernameOrEmail", "Please Active Your Account First");
                }
            }
            else
            {
                ModelState.AddModelError("UsernameOrEmail", "Username Or Email Or Password Invalid");
                return View(signIn);
            }

            return View();
        }

        #endregion

        #region SignOut

        [Authorize]
        [Route("SignOut")]
        public IActionResult SignOutt()
        {
            SignOutViewModel signOutView = _mainService.GetUserForSignOut(User.Identity.Name);
            signOutView.AreYouSure = false;
            return View(signOutView);
        }

        [Authorize]
        [HttpPost]
        [Route("SignOut")]
        public IActionResult SignOutt(SignOutViewModel signOut)
        {
            if(signOut.AreYouSureStr == "True")
            {
                signOut.AreYouSure = true;
            }
            else
            {
                signOut.AreYouSure = false;
            }

            if(signOut.AreYouSure == false)
            {
                return View(signOut);
            }

            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        #endregion

        #region ForgotPassword

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword() => View();

        [Route("ForgotPassword")]
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            forgot.EmailOrUsername = FixText.FixTexts(forgot.EmailOrUsername);
            User user = _mainService.GetUserForgotPass(forgot.EmailOrUsername);

            if (user != null)
            {

                string Body = _render.RenderToStringAsync("ForgotView", user);
                EmailSenders.Send(user.Email, "Forgot!", Body);
                ViewBag.IsForgot = true;

                return View();
            }
            else
            {
                ModelState.AddModelError("EmailOrUsername", "Email is Not Valid");
                return View(forgot);
            }

        }
        #endregion

        #region ResetPassword

        public IActionResult ResetPassword( string id )
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode = id,
            });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
            {
                return View(reset);
            }


            User user = _mainService.GetUserByActiveCode(reset.ActiveCode);
            if(user != null)
            {
                string hashPassword = PasswordHashC.EncodePasswordMd5(reset.Password);
                user.Password = hashPassword;
                user.ActiveCode = ActiveCodeGen.GenerateCode();

                _mainService.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

        #endregion
    }
}
