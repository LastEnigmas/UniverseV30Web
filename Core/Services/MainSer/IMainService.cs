using Core.DTOs.MainViewModels;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.MainSer
{
    public interface IMainService
    {
        bool IsUsername(string username);
        bool IsEmail(string email);
        void Add(User user);
        RegisterViewModel Register(string activeCode);
        RegisterViewModel UsernameEmailModel(string activecode);
        User SignInUser(SignInViewModel signIn);
        User GetUserForgotPass(string usernameOrEmail);
        UserInfoViewModel GetUserInfo(string username);
        SignOutViewModel GetUserForSignOut(string username);
        User GetUserByActiveCode(string activecode);    
        void Update(User user);
        void Save();
    }
}
