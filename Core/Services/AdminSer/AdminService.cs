using Core.DTOs.AdminViewModel;
using Data.Model;
using DataApp.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.AdminSer
{
    public class AdminService : IAdminService
    {
        private readonly MyDbContext _db;
        public AdminService(MyDbContext db)
        {
            _db = db;
        }

        public AdmingetAllUserViewModel GetAllUser(int pageId = 1, string filterUsername = "", string filterEmail = "")
        {
            IQueryable<User> result = _db.Users;

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email == filterEmail);
            }

            if (!string.IsNullOrEmpty(filterUsername))
            {
                result = result.Where(u => u.Username == filterUsername);
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            AdmingetAllUserViewModel Userlist = new AdmingetAllUserViewModel();
            Userlist.CurrentPage = pageId;
            Userlist.Users = result.OrderBy(u => u.CreateTime).Skip(skip).Take(take).ToList();

            return Userlist;
        }
    }
}
