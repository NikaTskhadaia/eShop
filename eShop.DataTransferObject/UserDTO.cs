using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public Guid? SessionId { get; set; }
        public string ActivateCode { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
    }

    public enum UserRole
    {
        SuperAdmin = 1,
        Admin = 2,
        User = 3
    }
}
