using AutoMapper;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Aggreagates;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserDomainService _userDomainService;

        public UserApplicationService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public UserAuthResponseDTO Login(LoginDTO user)
        {
            UserEntity userModel = new();

            userModel.Set(AutomapperExtensions.MapObject<LoginDTO, UserEntity>(user)); 
            
            return new UserAuthResponseDTO()
            {
                Messages = _userDomainService.Login(userModel),
                SessionID = userModel.SessionId
            };
        }

        public void Logout(Guid sessionId)
        {
            _userDomainService.Logout(sessionId);
        }
    }
}
