using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.MainViewModels
{
    public class SignOutViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool AreYouSure { get; set; }
        public string AreYouSureStr { get; set; }

    }
}
