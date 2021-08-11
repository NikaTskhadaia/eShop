using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IUserApplicationService
    {
        UserAuthResponseDTO Login(LoginDTO user);
        void Logout(Guid sessionId);
    }
}
