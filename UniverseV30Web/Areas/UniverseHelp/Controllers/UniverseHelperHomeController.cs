using Core.DTOs.UniverseViewModel;
using Core.Services.UniverseSer;
using Data.Model;
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
            ViewBag.IsTextt = true;
            ViewBag.IsUrll = true;
            ViewBag.IsImagee = true;

            if (!_universeService.IsText(article))
            {
                ViewBag.IsTextt = false;
                return View(article);
            }

            if (!_universeService.IsLink(article.LinkUrl))
            {
                ViewBag.IsUrll = false;
                return View(article);
            }

            if (!_universeService.IsImage(article.ArticleProfile))
            {
                ViewBag.IsImagee = false;
                return View(article);
            }

            Article MyArticle = new Article()
            {
                UsernameUser = User.Identity.Name,
                Title = article.Title,
                LinkUrl = article.LinkUrl,
                ShortDescription = article.ShortDescription,
                Body = article.Body,
                Author = article.Author,
                SubjectId = article.SubjectId,
            };


            
            return View();
        }

        #endregion
    }
}
