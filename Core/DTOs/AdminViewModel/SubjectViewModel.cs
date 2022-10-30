using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.AdminViewModel
{
    public class SubjectViewModel
    {
        [Required(ErrorMessage = "Please Add Nmae")]
        public string SubjectName { get; set; }
        [Required(ErrorMessage = "Please Add Nmae")]
        public string Description { get; set; }
    }
}
