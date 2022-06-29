using Mail_App.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.IServices
{
    public interface IAuthenticationManager
    {
        string GetToken(UserTokenModel userDate);
    }
}
