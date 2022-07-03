using Mail_App.IServices;
using Mail_App.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
    public class SendMailController : Controller
    {
        private readonly IMailService mailService;
        public SendMailController(IMailService mail)
        {
            mailService = mail;
        }

        [HttpPost("{newUser}")]
        [Route("SendNewMail")]
        public ActionResult<Response> SendNewMail(NewMail newMail)
        {
            if (newMail.Subject != null || newMail.Content != null)
            {
                var User = HttpContext.User.Claims.ToList();
                string id = null, emailid = null;
                foreach (var item in User)
                {
                    if (item.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber")
                    {
                        id = item.Value;
                    }
                    if (item.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                    {
                        emailid = item.Value;
                    }
                }
                if (id != null && emailid != null)
                {
                    newMail.FromId = Convert.ToInt32(id);
                    newMail.FromMail = emailid;
                    return mailService.SaveMail(newMail);
                }
            }
            return new Response
            {
                Status = false,
                data = "",
                Messege = ""
            };
        }
    }
}
