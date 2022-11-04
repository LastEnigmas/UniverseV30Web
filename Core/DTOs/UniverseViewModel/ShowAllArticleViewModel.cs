using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.DTOs.UniverseViewModel
{
    public class ShowAllArticleViewModel
    {
        public List<Article> articles { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
