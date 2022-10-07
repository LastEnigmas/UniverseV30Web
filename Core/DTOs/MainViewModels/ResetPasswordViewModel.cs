﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.DTOs.MainViewModels
{
    public class ResetPasswordViewModel
    {
        public string ActiveCode { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "RePassword")]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
