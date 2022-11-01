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
        void AddArticle(Article article);
        void Save();
    }
}
