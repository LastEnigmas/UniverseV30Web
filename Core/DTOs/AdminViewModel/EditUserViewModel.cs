using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.DTOs.AdminViewModel
{
    public class EditUserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username Required")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Is Active ?")]
        [Display(Name = "IsActive")]
        public string IsActiveStr { get; set; }
        public bool IsActive { get; set; }

    }
}
