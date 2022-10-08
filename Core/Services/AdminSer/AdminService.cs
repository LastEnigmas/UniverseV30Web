using Core.Convertor;
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

        public bool CheckForEdit(EditUserViewModel userEdit)
        {
            User user = GetUserById(userEdit.Id);
            if(user.Username == userEdit.Username)
            {
                return false;
            }else if(user.Email == userEdit.Email)
            {
                return false;
            }

            bool Result;
            Result = IsEmail(FixText.FixTexts(userEdit.Email));
            if(Result != true)
            {
                return false;
            }

            Result = IsUsername(FixText.FixTexts(userEdit.Username));
            if(Result != true)
            {
                return false;
            }

            user.Username = userEdit.Username;
            user.Email = userEdit.Email;
            user.IsActive = userEdit.IsActive;

            Update(user);
            return true;
        }

        public void Delete(User user)
        {
            _db.Users.Remove(user);
            Save();
        }

        public bool DoDeleteUser(DeleteUserViewModel delete)
        {

            User user = _db.Users.SingleOrDefault( u => u.Id == delete.Id);
            if(user == null)
            {
                return false;
            }

            Delete(user);
            return true;

        }

        public EditUserViewModel EditUserById(int id)
        {
            EditUserViewModel user = new EditUserViewModel();
            User user1 = new User();
            user1 = GetUserById(id);

            user.Id = user1.Id;
            user.Username = user1.Username;
            user.IsActive = user1.IsActive;
            user.Email = user1.Email;

            return user;
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

        public DeleteUserViewModel GetDeleteUser(int id)
        {
            User user = _db.Users.SingleOrDefault(u => u.Id == id);
            if(user == null)
            {
                return null;
            }

            DeleteUserViewModel delete = new DeleteUserViewModel()
            {
                Id = id,
                Username = user.Username,
                Email = user.Email,
            };

            return delete;
        }

        public User GetUserById(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public bool IsEmail(string email)
        {
            return _db.Users.Any(u => u.Email == email);
        }

        public bool IsUsername(string username)
        {
            return _db.Users.Any(u => u.Username == username);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            Save();
        }
    }
}
