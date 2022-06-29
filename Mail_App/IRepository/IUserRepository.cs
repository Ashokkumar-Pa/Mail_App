using Mail_App.Models;
using Mail_App.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.IRepository
{
    public interface IUserRepository
    {
        int AddNewUser(UserProfile user);
        bool AddNewUserPassword(UserPassword user);
        IdCheck GetUserProfile(string EmailorPhone);
        UserTokenModel GetUserProfile(PasswordCheck passwordCheck);

    }
}
