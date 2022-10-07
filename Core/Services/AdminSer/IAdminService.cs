using Core.DTOs.AdminViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.AdminSer
{
    public interface IAdminService
    {
        AdmingetAllUserViewModel GetAllUser(int pageId = 1, string filterUsername = "", string filterEmail = "");
    }
}
