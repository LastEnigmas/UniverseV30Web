using Core.DTOs.MainViewModels;
using Core.Services.GlobalSer;
using Microsoft.AspNetCore.Mvc;

namespace UniverseV30Web.Areas.Global.Controllers
{
    [Area("Global")]
    public class GlobalHomeController : Controller
    {
        private readonly IGlobolService _globolService;
        public GlobalHomeController( IGlobolService globolService )
        {
            _globolService = globolService;
        }

        #region Register

        public IActionResult Register(string id)
        {

            RegisterViewModel register = _globolService.Register(id);
            if(register == null)
            {
                return NotFound();
            }
            ViewBag.IsRegister = true;
            return View(register);
        }

        #endregion
    }
}
