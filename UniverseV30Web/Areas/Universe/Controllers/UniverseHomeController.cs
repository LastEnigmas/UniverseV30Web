using Core.DTOs.UniverseViewModel;
using Core.Services.UniverseSer;
using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniverseV30Web.Areas.Universe.Controllers
{
    [Area("Unviverse")]
    [Authorize]
    public class UniverseHomeController : Controller
    {
        private readonly IUniverseService _universeService;

        public UniverseHomeController(IUniverseService universeService)
        {
            _universeService = universeService;
        }

        public IActionResult Index()
        {
            return View();
        }

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
