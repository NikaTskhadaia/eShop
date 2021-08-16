using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eShop.DomainModel.Aggreagates
{
    public class UserEntity
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
        public DateTime? DateDeleted { get; set; }


        public UserEntity Get(UserOperationType operationType)
        {
            switch (operationType)
            {
                case UserOperationType.Login:
                    this.SessionId = Guid.NewGuid();
                    break;
                case UserOperationType.Registration:
                    break;
                case UserOperationType.Activation:
                    break;
                default:
                    break;
            }

            return this;
        }

        public void Set(UserEntity user)
        {
            Id = user.Id;
            SessionId = user.SessionId;
            ActivateCode = user.ActivateCode;
            IsActive = user.IsActive;
            Email = user.Email;
            PasswordHash = PasswordHashGenerator(user.PasswordHash);
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateCreated = user.DateCreated;
            DateChanged = user.DateChanged;
            DateDeleted = user.DateDeleted;
        }

        private string PasswordHashGenerator (string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }
                return hashedInputStringBuilder.ToString();
            }
        }

        public List<string> IsValid(UserValidationType validationType)
        {
            switch (validationType)
            {
                case UserValidationType.Login:
                    return LoginValidation();

                case UserValidationType.Registration:
                    return RegistrationValidation();

                case UserValidationType.Activation:
                    return ActivationValidation();
                default:
                    return new List<string>();
            }
        }

        private List<string> ActivationValidation()
        {
            return new List<string>();
        }

        private List<string> RegistrationValidation()
        {
            return new List<string>();
        }

        private List<string> LoginValidation()
        {
            List<string> errorResults = new();

            if (string.IsNullOrEmpty(Email))
            {
                errorResults.Add(UserErrors.EMAIL_IS_EMPTY.ToString());
            }

            if (!Regex.IsMatch(Email, @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                errorResults.Add(UserErrors.PASSWORD_IS_NOT_MATCH.ToString());
            }

            if (string.IsNullOrEmpty(PasswordHash))
            {
                errorResults.Add(UserErrors.PASSWORD_IS_EMPTY.ToString());
            }

            return errorResults;
        }

        public enum UserErrors
        {
            EMAIL_IS_EMPTY = 0,
            EMAIL_IS_NOT_VALID = 1,
            PASSWORD_IS_EMPTY = 2,
            PASSWORD_IS_NOT_MATCH = 3
        }

        public enum UserValidationType
        {
            Login = 0,
            Registration = 1,
            RegistrationForAdmin = 2,
            Activation = 3
        }

        public enum UserOperationType
        {
            Login = 0,
            Registration = 1,
            Activation = 2
        }
    }
}
