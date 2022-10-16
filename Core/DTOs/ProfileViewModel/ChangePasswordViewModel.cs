using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.ProfileViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string ReNewPassword { get; set; }
        [Required]
        public string CurrentPassowrd { get; set; }
    }
}
