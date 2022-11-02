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
                viewModel.PictureTitle = NameGenerator.GenerateUniqCode() + Path.GetExtension(viewModel.ArticleProfile.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ArticlePicture", viewModel.PictureTitle);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    viewModel.ArticleProfile.CopyTo(stream);
                    article.Picture = viewModel.PictureTitle;
                    article.PictureTitle = viewModel.PictureTitle;
                }
            }
            

            _db.Articles.Add(article);
            Save();
        }

        public string FindSubject(int subjectId)
        {
            Subject subject = _db.Subjects.SingleOrDefault( u => u.SubjectId == subjectId);
            if(subject != null)
            {
                return subject.SubjectName;
            }

            return "NoData";
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
