﻿using Microsoft.AspNetCore.Identity;

namespace UserManagementApp.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
