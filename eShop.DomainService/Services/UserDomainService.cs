using eShop.DataTransferObject;
using eShop.DomainModel.Aggreagates;
using eShop.DomainService.RepositoryInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eShop.DomainModel.Aggreagates.UserEntity;

namespace eShop.DomainService.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<string> Login(UserEntity user)
        {
            List<string> validationResponse = new List<string>();

            validationResponse = user.IsValid(UserValidationType.Login);

            if (validationResponse.Count == 0)
            {
                if (!_userRepository.Login(user.Get(UserOperationType.Login)))
                {
                    return new List<string> { "EMAIL_PASSWORD_ACTIVATE_NOT_VALID" };
                }

                return validationResponse;
            }
            else
            {
                return validationResponse;
            }

        }

        public bool CheckSessionIsValid(Guid SessionID)
        {
            return _userRepository.CheckSessionIsValid(SessionID);
        }

        public void Logout(Guid sessionId)
        {
            _userRepository.Logout(sessionId);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserDTO Get(Guid id)
        {
            return _userRepository.Get(id);
        }

        public void Delete(Guid id)
        {
            _userRepository.Delete(id);
        }

        public void SaveUser(UserDTO userDto)
        {
            _userRepository.SaveUser(userDto);
        }
    }
}
