using Mail_App.IServices;
using Mail_App.ResponseModels;
using Mail_App.Services;
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
    public class LoginController : ControllerBase
    {
        private readonly ILogin service;
        public LoginController(ILogin loginService)
        {
           service = loginService;
        }
        [HttpPost("{newUser}")]
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
        [Route("Login/{id}")]
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
        [HttpGet]
        [Route("CheckUserPassword/{password}")]
        public ActionResult<Response> CheckPasword(PasswordCheck password)
        {
            if (password != null)
            {
                return service.CheckUserPassword(password);
            }
            return new Response()
            {
                Status = false,
                Messege = "Input User Id or Phone Number",
                data = null
            };
        }
        [HttpGet]
        public string Index()
        {
            return "Login Index action method";
        }
    }
}
