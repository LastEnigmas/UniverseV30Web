using Core.DTOs.UniverseViewModel;
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

        public void AddArticle(Article article)
        {
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
