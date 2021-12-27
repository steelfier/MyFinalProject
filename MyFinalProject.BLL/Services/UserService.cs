using MyFinalProject.BLL.Interfaces;
using MyFinalProject.BLL.Infrastructure;
using MyFinalProject.BLL.ViewModels.UserVM;
using MyFinalProject.DAL;
using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BLL.Services
{
    public class UserService : IUserService
    {
        private AppDbContext db { get; set; }

        public UserService(AppDbContext _db)
        {
            db = _db;
        }

        public bool LogIn(AccountVM acc)
        {
            try
            {
                var userDb = db.Users.Single(m=>m.Login == acc.Login && m.PassHash == acc.PassHash);
                if (userDb == null)
                {
                    throw new Exception("Такого пользователя не существует.");
                }
                StaticUserAccount.Id = userDb.Id;
                StaticUserAccount.Name = userDb.Login;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool LogOut(AccountVM acc)
        {
            try
            {
                StaticUserAccount.Id = Guid.Empty;
                StaticUserAccount.Name = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegisterUser(AccountVM acc)
        {
            try
            {
                if (db.Users.Any(m => m.Login == acc.Login))
                {
                    throw new Exception("Пользователь с таким логином уже существует.");
                }
                var newUser = new User()
                {
                    Login = acc.Login,
                    PassHash = acc.PassHash
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
