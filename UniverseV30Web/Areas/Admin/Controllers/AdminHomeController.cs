using Core.DTOs.AdminViewModel;
using Core.Services.AdminSer;
using Microsoft.AspNetCore.Mvc;

namespace UniverseV30Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminHomeController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index(int pageId = 1, string filterUsername = "", string filterEmail = "")
        {
            AdmingetAllUserViewModel Alluser = new AdmingetAllUserViewModel();
            Alluser = _adminService.GetAllUser(pageId, filterEmail, filterUsername);
            return View();
        }
    }
}
