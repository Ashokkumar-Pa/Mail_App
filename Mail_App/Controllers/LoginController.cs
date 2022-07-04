using Mail_App.IServices;
using Mail_App.ResponseModels;
using Mail_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly ILogin service;
        public LoginController(ILogin loginService)
        {
           service = loginService;
        }
        [HttpPost("{newUser}")]
        [AllowAnonymous]
        [Route("Register")]

        public ActionResult<Response> Register(Register newUser)
        {
            if (ModelState.IsValid && newUser.Password == newUser.ConfirmationPassword )
            {
                if (service.AddNewUser(newUser))
                {
                    return new Response()
                    {
                        Status = true,
                        Messege = "",
                        data = null
                    };
                }
            }
            return new Response()
            {
                Status = false,
                Messege = ModelState.IsValid ? "Invalied Fields" : "Invalied Passwords",
                data = null
            };
        }
        [HttpGet]
        [Route("Login")]
        [AllowAnonymous]

        public ActionResult<Response> CheckUserId( string id)
        {
            if (id != null)
            {
                return service.CheckUserId(id);
            }
            return new Response()
            {
                Status = false,
                Messege = "Input User Id or Phone Number",
                data = null
            };
        }
        [HttpGet("CheckUserPassword")]
        [AllowAnonymous]
        public ActionResult<Response> CheckPasword(string password, int id)
        {
            if (password != null && id > 0)
            {
                PasswordCheck passwordCheck = new PasswordCheck
                {
                    Password = password,
                    Id = id
                };
                return service.CheckUserPassword(passwordCheck);
            }
            return new Response()
            {
                Status = false,
                Messege = "Input User Id or Phone Number",
                data = null
            };
        }
        //[AllowAnonymous]
        [HttpGet]
        public string Index()
        {
            return "Login Index action method";
        }
    }
}
