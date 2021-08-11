using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
