using eShop.DataBaseRepository.Data;
using eShop.DataBaseRepository.Models;
using eShop.DataTransferObject;
using eShop.DomainModel.Aggreagates;
using eShop.DomainService.RepositoryInterfaces;
using eShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

        public IEnumerable<UserDTO> GetAll()
        {
            using (eShopDBContext context = new())
            {
                var users = (from u in context.Users
                             where u.DateDeleted == null
                             select u).ToList();

                return AutomapperExtensions.MapList<User, UserDTO>(users);
            }
        }

        public UserDTO Get(Guid id)
        {
            using (eShopDBContext context = new())
            {
                var user = (from u in context.Users
                           where u.DateDeleted == null
                           select u).FirstOrDefault();

                return AutomapperExtensions.MapObject<User, UserDTO>(user);
            }
        }

        public void Delete(Guid id)
        {
            using (eShopDBContext context = new())
            {
                var user = (from u in context.Users
                            where u.DateDeleted == null
                            select u).FirstOrDefault();

                if (user is not null)
                {
                    user.DateDeleted = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        public void SaveUser(UserDTO userDto)
        {
            using (TransactionScope scope = new())
            {
                using (eShopDBContext context = new())
                {
                    if (userDto.Id == Guid.Empty)
                    {
                        User u = AutomapperExtensions.MapObject<UserDTO, User>(userDto);
                        u.PasswordHash = PasswordHasher.PasswordHashGenerator("admin");
                        context.Users.Add(u);
                        context.SaveChanges();
                        context.UsersInRoles.Add(new() { RoleId = (int)UserRole.Admin, UserId = u.Id });
                        context.SaveChanges();
                    }
                    else
                    {
                        var user = (from u in context.Users
                                    where u.DateDeleted == null
                                    select u).FirstOrDefault();

                        if (user is not null)
                        {
                            user.Email = userDto.Email;
                            user.FirstName = userDto.FirstName;
                            user.LastName = userDto.LastName;
                            user.DateChanged = DateTime.Now;
                            context.SaveChanges();
                        }
                    }

                    scope.Complete();
                }
            }
            
        }
    }
}
