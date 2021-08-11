using eShop.DomainModel.Aggreagates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool Login(UserEntity user);
        void Logout(Guid sessionId);
        bool CheckSessionIsValid(Guid SessionID);
    }
}
