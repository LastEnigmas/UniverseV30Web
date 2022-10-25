using Core.DTOs.MainViewModels;
using Core.Generator;
using Core.Security;
using Data.Model;
using DataApp.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.MainSer
{
    public class MainService : IMainService
    {
        private readonly MyDbContext _db;
        public MainService(MyDbContext db)
        {
            _db = db;
        }

        public void Add(User user)
        {
            _db.Users.Add(user);
            Save();
        }
        public User GetUserByActiveCode(string activecode)
        {
            return _db.Users.SingleOrDefault(u => u.ActiveCode == activecode);
        }
        public User GetUserForgotPass(string usernameOrEmail)
        {
            User user = _db.Users.FirstOrDefault(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail);
            if(user == null)
            {
                return null;
            }

            return user;
        }
        public SignOutViewModel GetUserForSignOut(string username)
        {
            User user = _db.Users.FirstOrDefault(x => x.Username == username);
            SignOutViewModel signOutViewModel = new SignOutViewModel();

            signOutViewModel.Username = user.Username;
            signOutViewModel.Email = user.Email;

            return signOutViewModel;
        }
        public UserInfoViewModel GetUserInfo(string username)
        {
            User user = _db.Users.FirstOrDefault(x => x.Username == username);
            UserInfoViewModel userInfo = new UserInfoViewModel();
            userInfo.Username = user.Username;
            userInfo.Email = user.Email;

            return userInfo;   
        }
        public bool IsEmail(string email)
        {
            return _db.Users.Any(u => u.Email == email);
        }
        public bool IsUsername(string username)
        {
            return _db.Users.Any(u => u.Username == username);
        }
        public RegisterViewModel Register(string activeCode)
        {
            User user = new User();

            user = _db.Users.SingleOrDefault( u => u.ActiveCode == activeCode);
            if(user == null)
            {
                return null;
            }

            user.ActiveCode = ActiveCodeGen.GenerateCode();
            user.IsActive = true;
            Update(user);

            RegisterViewModel register = new RegisterViewModel()
            {
                Username = user.Username,
                Email = user.Email,
            };
            return register ;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public User SignInUser(SignInViewModel signIn)
        {
            User user = _db.Users.SingleOrDefault(u => u.Username == signIn.UsernameOrEmail || u.Email == signIn.UsernameOrEmail);
            string hashPassword = PasswordHashC.EncodePasswordMd5(signIn.Password);
            if((user == null ) || (user.Password != hashPassword))
            {
                return null;
            }

            return user;
        }
        public void Update(User user)
        {
            _db.Update(user);
            Save();
        }
        public RegisterViewModel UsernameEmailModel(string activecode)
        {

            User user = new User();
            user = _db.Users.SingleOrDefault(u => u.ActiveCode == activecode);
            RegisterViewModel register = new RegisterViewModel();
            register.Username = user.Username;
            register.Email = user.Email;
            return register;
        }
    }
}
