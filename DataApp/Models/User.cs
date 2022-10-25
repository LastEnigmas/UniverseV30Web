using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Description { get; set; } = "";
        public bool IsActive { get; set; }
        public string ActiveCode { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Picture { get; set; }
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
