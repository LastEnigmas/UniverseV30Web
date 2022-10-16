using Core.DTOs.ProfileViewModel;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProfileSer
{
    public interface IProfileService
    {
        InfoUserViewModel GetUserInfo(string username);
        User GetUserById(string username);
        bool IsUsername(string username);
        bool IsEmail(string email);
        bool CheackEdit(InfoUserViewModel infoUser);
        bool SendNewConfirmEmail(User user);
        void Update(User users);
        void Save();
    }
}
