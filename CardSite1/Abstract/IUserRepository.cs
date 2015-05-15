using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardSite1.Models;

namespace CardSite1.Abstract
{
    public interface IUserRepository
    {
        IQueryable<UserModel> Users { get; }
        IQueryable<RoleModel> Roles { get; }
        void RegisterUser(RegistrationModel registration);
        void DeleteUser(int userId);
        void SaveChanges(UserModel user);
        UserModel GetUser(LoginModel login);
        bool UserExists(string login, string email);
        void BlockUser(int id);
        void UnBlockUser(int id);
    }
}
