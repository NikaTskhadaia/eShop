using eShop.DataBaseRepository.Data;
using eShop.DomainModel.Aggreagates;
using eShop.DomainService.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository
{
    public class UserRepository : IUserRepository
    {
        public bool Login(UserEntity userModel)
        {
            using (eShopDBContext context = new())
            {
                var query = (from user in context.Users
                             where user.Email == userModel.Email && user.PasswordHash == userModel.PasswordHash &&
                             user.DateDeleted == null && user.IsActive == true
                             select user).FirstOrDefault();

                if (query is not null)
                {
                    query.SessionId = userModel.SessionId;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool CheckSessionIsValid(Guid SessionID)
        {
            using (eShopDBContext context = new ())
            {
                var query = (from user in context.Users
                             where user.SessionId == SessionID &&
                             user.IsActive == true &&
                             user.DateDeleted == null
                             select user).FirstOrDefault();

                return query is not null;
            }
        }

        public void Logout(Guid sessionId)
        {
            using (eShopDBContext context = new())
            {
                var query = (from user in context.Users
                             where user.SessionId == sessionId
                             select user).FirstOrDefault();

                if (query is not null)
                {
                    query.SessionId = null;
                    context.SaveChanges();
                }
            }
        }
    }
}
