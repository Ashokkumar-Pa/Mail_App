using Mail_App.DatabaseContext;
using Mail_App.IServices;
using Mail_App.ResponseModels;
using Mail_App.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mail_App.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Mail_App.Services
{
    public class LoginService : ILogin
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthenticationManager authenticationManager;
        public LoginService(IUserRepository _userRepository, IAuthenticationManager _authenticationManager)
        {
            userRepository = _userRepository;
            authenticationManager =_authenticationManager;
        }

        public bool AddNewUser(Register newUser)
        {
            try
            {
                var user = new UserProfile
                {
                    EmailAddress = newUser.EmailAddress,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    PrimaryAddress = newUser.PrimaryAddress,
                    TemporaryAddress = newUser.TemporaryAddress,
                    PhoneNumber = newUser.PhoneNumber,
                    PinCode = newUser.PinCode,
                    CreatedOn = DateTime.Now,
                    LastChangesOn = DateTime.Now
                };
                var userid = userRepository.AddNewUser(user);

                UserPassword userPassword = new UserPassword
                {
                    UserId = userid,
                    Password = newUser.Password,
                    LastChangesOn = DateTime.Today
                };

                if (userRepository.AddNewUserPassword(userPassword))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Response CheckUserId(string id)
        {
            var user = userRepository.GetUserProfile(id);
            if (user != null)
            {


                return new Response
                {
                    Status = true,
                    Messege = "",
                    data = user
                };
            }
            return new Response
            {
                Status = false,
                Messege = "Input User Id or Phone Number",
                data = null
            };
        }

        public Response CheckUserPassword(PasswordCheck passwordCheck)
        {
            var user = userRepository.GetUserProfile(passwordCheck);
            if (user != null)
            {

                var token = authenticationManager.GetToken(user);

                return new Response
                {
                    Status = true,
                    Messege = "Valied Id",
                    data = token
                };
            }
            return new Response
            {
                Status = false,
                Messege = "Input User Id or Phone Number",
                data = null
            };
        }
    }
}
