using Core.Convertor;
using Core.DTOs.ProfileViewModel;
using Core.Security;
using Core.Sender;
using Data.Model;
using DataApp.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Convertor.ViewToString;

namespace Core.Services.ProfileSer
{
    public class ProfileService : IProfileService
    {
        private readonly MyDbContext _db;
        private readonly IViewRenderService _render;
        public ProfileService(MyDbContext db , IViewRenderService render)
        {
            _render = render;
            _db = db;
        }



        public InfoUserViewModel GetUserInfo(string username)
        {
            User user = _db.Users.SingleOrDefault(u => u.Username == username);
            if(user == null)
            {
                return null;
            }

            InfoUserViewModel infoUser = new InfoUserViewModel()
            {
                Id = user.Id,
                Username = username,
                Email = user.Email,
                Description = user.Description,
            };

            return infoUser;
        }
        public bool CheackEdit(InfoUserViewModel infoUser)
        {
            User user = _db.Users.SingleOrDefault(u => u.Id == infoUser.Id);
            if(user == null)
            {
                return false;
            }


            // Email Section
            if(user.Email != infoUser.Email)
            {
                if (IsEmail(FixText.FixTexts(infoUser.Email)))
                {
                    return false;
                }
                else
                {
                    bool Result;
                    Result = SendNewConfirmEmail(user);
                    if (Result != true)
                    {
                        return false;
                    }

                    user.IsActive = false;
                    user.Email = FixText.FixTexts(infoUser.Email);
                }
            }

            // Username Section 
            if(user.Username != infoUser.Username)
            {
                if (IsUsername(FixText.FixTexts(infoUser.Username)))
                {
                    return false;
                }
                else
                {
                    user.Username = FixText.FixTexts(infoUser.Username);
                }
            }


            user.Description = infoUser.Description;

            Update(user);
            return true;
            
        }
        public bool SendNewConfirmEmail(User user)
        {
            /* When User Want Change His Email
             * We Send Her An Email and we riderect
             * her in {Main} Area
             */
            try
            {
                string Body = _render.RenderToStringAsync("registerView", user);
                EmailSenders.Send(user.Email, "Register", Body);
                return true;

            }catch(Exception e)
            {
                return false;
            }

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

        public bool IsUsername(string username)
        {
            return _db.Users.Any(u => u.Username == username);
        }

        public bool IsEmail(string email)
        {
            return _db.Users.Any(u => u.Email == email);
        }

        public User GetUserById(string username)
        {
            return _db.Users.SingleOrDefault(u => u.Username == username);
        }
    }
}
