using Mail_App.ResponseModels;
using Mail_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.IServices
{
    public interface ILogin
    {
        bool AddNewUser(Register register);
        Response CheckUserId(string id);
        Response CheckUserPassword(PasswordCheck passwordCheck);


    }
}
