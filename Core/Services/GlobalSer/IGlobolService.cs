using Core.DTOs.MainViewModels;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.GlobalSer
{
    public interface IGlobolService
    {

        RegisterViewModel Register(string id);
        void Update(User user);
        void Save();
    }
}
