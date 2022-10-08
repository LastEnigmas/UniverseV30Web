using Core.DTOs.AdminViewModel;
using Core.Services.AdminSer;
using Data.Model;
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
            AdmingetAllUserViewModel allUser = new AdmingetAllUserViewModel();
            allUser = _adminService.GetAllUser(pageId, filterUsername, filterEmail);
            return View(allUser);
        }


        #region EditUser

        [Route("EditUser")]
        public IActionResult EditUser(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                EditUserViewModel editVm = _adminService.EditUserById(id);
                if(editVm != null)
                {
                    if(editVm.IsActive == true)
                    {
                        editVm.IsActiveStr = "True";
                    }
                    else
                    {
                        editVm.IsActiveStr = "False";
                    }
                    return View(editVm);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [Route("EditUser")]
        [HttpPost]
        public IActionResult EditUser(EditUserViewModel editUser)
        {
            if(editUser.IsActiveStr == "True" || editUser.IsActiveStr == "true")
            {
                editUser.IsActive = true;
            }
            else
            {
                editUser.IsActive = false;
            }
            ViewBag.EditValidation = _adminService.CheckForEdit(editUser);
            return View(editUser);

        }

        #endregion

        #region Deleteuser

        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            DeleteUserViewModel deleteUser = _adminService.GetDeleteUser(id);
            if(deleteUser == null)
            {
                return NotFound();
            }

            return View(deleteUser);
        }


        [Route("DeleteUser")]
        [HttpPost]
        public IActionResult DeleteUser(DeleteUserViewModel delete)
        {
            ViewBag.IsDelete = _adminService.DoDeleteUser(delete);
            return View(delete);
        }

        #endregion

    }
}
