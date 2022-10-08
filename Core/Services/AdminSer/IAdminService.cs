﻿using Core.DTOs.AdminViewModel;
using Data.Model;
using DataApp.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.AdminSer
{
    public interface IAdminService
    {
        User GetUserById(int id);
        bool IsEmail(string email);
        bool IsUsername(string username);
        EditUserViewModel EditUserById(int id);
        bool CheckForEdit(EditUserViewModel userEdit);
        AdmingetAllUserViewModel GetAllUser(int pageId = 1, string filterUsername = "", string filterEmail = "");
        void Update(User user);
        void Save();
    }
}