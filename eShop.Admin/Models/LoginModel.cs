using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
