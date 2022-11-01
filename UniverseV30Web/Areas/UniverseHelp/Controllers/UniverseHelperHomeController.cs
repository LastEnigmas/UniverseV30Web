using Core.DTOs.UniverseViewModel;
using Core.Services.UniverseSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseV30Web.Areas.UniverseHelp.Controllers
{

    [Area("UniverseHelp")]
    [Authorize]
    public class UniverseHelperHomeController : Controller
    {
        private readonly IUniverseService _universeService;
        public UniverseHelperHomeController(IUniverseService universeService)
        {
            _universeService = universeService;
        }
        public IActionResult Index() => View();

        #region Create Universe

        [Route("CreateUniverse")]
        public IActionResult CreateUniverse()
        {
            return View();
        }

        [Route("CreateUniverse")]
        [HttpPost]

        public IActionResult CreateUniverse(ArticleViewModel article)
        {
            return View();
        }

        #endregion
    }
}
