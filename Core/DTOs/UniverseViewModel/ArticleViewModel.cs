using Data.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.DTOs.UniverseViewModel
{
    public class ArticleViewModel
    {

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Body")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "PictureTitle")]
        public string PictureTitle { get; set; }
        public IFormFile ArticleProfile { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Author")]
        public string Author { get; set; }
        public string LinkUrl { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "SubjectId")]
        public int SubjectId { get; set; }
    }
}
