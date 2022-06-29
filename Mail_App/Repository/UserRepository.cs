using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mail_App.IRepository;
using Mail_App.Models;
using Mail_App.DatabaseContext;
using Mail_App.ResponseModels;

namespace Mail_App.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;

        public UserRepository(DataContext _Context)
        {
            db = _Context;
        }
        public int AddNewUser(UserProfile user)
        {
            try
            {
                db.User.Add(user);
                db.SaveChanges();
                return user.UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }

        public bool AddNewUserPassword(UserPassword user)
        {
            try
            {
                db.UserPassword.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        IdCheck IUserRepository.GetUserProfile(string id)
        {
            return db.UserPassword.Where(f => f.User.EmailAddress == id || f.User.PhoneNumber == id).Select(s => new IdCheck
            {
                Name = s.User.FirstName + " " + s.User.LastName,
                Id = s.Id
            }).FirstOrDefault();
        }
        UserTokenModel IUserRepository.GetUserProfile(PasswordCheck passwordCheck)
        {
            return db.UserPassword.Where(f => f.Id == passwordCheck.Id && f.Password == passwordCheck.Password ).Select(s => 
            new UserTokenModel 
            { 
                Name = s.User.FirstName + " " + s.User.LastName,
                EmailAddress = s.User.EmailAddress,
                UserId = s.UserId
            }).FirstOrDefault();
        }
    }
}
