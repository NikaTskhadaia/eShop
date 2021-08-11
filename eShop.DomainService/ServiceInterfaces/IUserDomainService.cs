using eShop.DomainModel.Aggreagates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IUserDomainService
    {
        List<string> Login(UserEntity user);
        void Logout(Guid sessionId);
        bool CheckSessionIsValid(Guid SessionID);
    }
}
