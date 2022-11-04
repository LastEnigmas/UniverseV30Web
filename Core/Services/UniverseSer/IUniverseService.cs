using Core.DTOs.UniverseViewModel;
using Data.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.UniverseSer
{
    public interface IUniverseService
    {
        bool IsText(ArticleViewModel article);
        bool IsLink(string link);
        bool IsImage(IFormFile file );
        string FindSubject(int subjectId);
        void AddArticle(Article article , ArticleViewModel viewModel);
        ShowAllArticleViewModel ShowSmallArticle(int pageId = 1, string filterTitle = "", string filterSubject = "");
        void Save();
    }
}
