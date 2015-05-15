﻿using System;
using System.Data.Entity;
using System.Linq;
using CardSite1.Abstract;
using CardSite1.Models;

namespace CardSite1.Concrete
{
    public class UserRepository : IUserRepository
    {
        public Context contex = new Context();

        public IQueryable<UserModel> Users
        {
            get { return contex.Users; }
        }

        public IQueryable<RoleModel> Roles
        {
            get { return contex.Roles; }
        }

        public void RegisterUser(RegistrationModel registration)
        {
            UserModel user = new UserModel
            {
                FirstName = registration.FirstName,
                LastName=registration.LastName,
                LoginName = registration.LoginName,
                RoleId = 2,
                Cookie = Guid.NewGuid().ToString(),
                Email = registration.Email,
                Password = registration.Password,
                IsConfirmed = false
            };
            contex.Users.Add(user);
            contex.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            UserModel user = contex.Users.Find(userId);
            contex.Users.Remove(user);
            contex.SaveChanges();
        }

        public void SaveChanges(UserModel user)
        {
            contex.Entry(user).State=EntityState.Modified;
            contex.SaveChanges();
        }

        public UserModel GetUser(LoginModel login)
        {
            return contex.Users.FirstOrDefault(k => k.Email == login.Email & k.Password == login.Password);
        }

        public bool UserExists(string login, string email)
        {
            if (contex.Users.FirstOrDefault(m => m.LoginName == login | m.Email == email) == null)
                return false;
            return true;
        }

        public void BlockUser(int userId)
        {
            UserModel user = contex.Users.Find(userId);
            user.RoleId += 3;
            contex.Entry(user).State=EntityState.Modified;
            contex.SaveChanges();
        }

        public void UnBlockUser(int userId)
        {
            UserModel user = contex.Users.Find(userId);
            user.RoleId -= 3;
            contex.Entry(user).State=EntityState.Modified;
            contex.SaveChanges();
        }
    }
}