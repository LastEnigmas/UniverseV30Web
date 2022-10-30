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
    public interface IAdminService
    {
        User GetUserById(int id);
        bool IsEmail(string email);
        bool IsUsername(string username);
        bool DoDeleteUser(DeleteUserViewModel delete);
        DeleteUserViewModel GetDeleteUser(int id);
        EditUserViewModel EditUserById(int id);
        bool CheckForEdit(EditUserViewModel userEdit);
        AdmingetAllUserViewModel GetAllUser(int pageId = 1, string filterUsername = "", string filterEmail = "");
        bool IsSubject(string subjectName);
        void CreateSubject(Subject subject);
        void Update(User user);
        void Delete(User user);
        void Save();
    }
}
