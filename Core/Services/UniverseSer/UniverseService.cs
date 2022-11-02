using Core.DTOs.UniverseViewModel;
using Core.Generator;
using Data.Model;
using DataApp.MyDbContext;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.UniverseSer
{
    public class UniverseService : IUniverseService
    {
        private readonly MyDbContext _db;
        public UniverseService(MyDbContext db)
        {
            _db = db;
        }

        public void AddArticle(Article article , ArticleViewModel viewModel )
        {


            // Profile Picture 

            if( viewModel.ArticleProfile != null)
            {
                string imagePath = "";
                if(viewModel.Picture != "uniDef.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ArticlePicture", viewModel.Picture);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
            }
            //if (infoUser.UserProfile != null)
            //{
            //    string imagePath = "";
            //    if (infoUser.UserProfileName != "defult.jpg")
            //    {
            //        imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", infoUser.UserProfileName);
            //        if (File.Exists(imagePath))
            //        {
            //            File.Delete(imagePath);
            //        }
            //    }

            //    infoUser.UserProfileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(infoUser.UserProfile.FileName);
            //    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", infoUser.UserProfileName);
            //    using (var stream = new FileStream(imagePath, FileMode.Create))
            //    {
            //        infoUser.UserProfile.CopyTo(stream);

            //        user.Description = infoUser.Description;
            //        user.PictureTitle = infoUser.UserProfileName;
            //    }
            //}


            _db.Articles.Add(article);
            Save();
        }

        public bool IsImage(IFormFile file)
        {
            if(file == null)
            {
                return false;
            }

            return true;
        }

        public bool IsLink(string link)
        {
            if(link == null || link.Length < 5)
            {
                return false;
            }

            return true;
        }

        public bool IsText(ArticleViewModel article)
        {
            if((article.Author == null ) || (article.Body.Length < 15 ) ||
                (article.ShortDescription.Length < 7 ) || (article.Title.Length < 3) || (article.Title == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
