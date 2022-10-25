using Core.DTOs.MainViewModels;
using Core.Generator;
using Data.Model;
using DataApp.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.GlobalSer
{
    public class GlobalService : IGlobolService
    {
        private readonly MyDbContext _db;
        public GlobalService(MyDbContext db)
        {
            _db = db;
        }

        public RegisterViewModel Register(string id)
        {
            User user = _db.Users.SingleOrDefault(u => u.ActiveCode == id);
            if(user == null)
            {
                return null;
            }

            RegisterViewModel register = new RegisterViewModel()
            {
                Email = user.Email,
                Username = user.Username,
            };
            user.IsActive = true;
            user.ActiveCode = ActiveCodeGen.GenerateCode();
            Update(user);
            return register;
        }
        public void Update(User user)
        {
            _db.Update(user);
            Save();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
