using Microsoft.AspNetCore.Identity;

namespace UserManagementApp.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
        public string Designation { get; set; }
        public DateTime LoginTime { get; set; }

    }
}
