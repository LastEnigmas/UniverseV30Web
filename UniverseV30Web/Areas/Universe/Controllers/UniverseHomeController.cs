using Core.Services.UniverseSer;
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
    }
}
