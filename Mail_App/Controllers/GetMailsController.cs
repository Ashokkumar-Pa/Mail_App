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
    public class GetMailsController : Controller
    {
        private readonly IMailService mailService;
        public GetMailsController(IMailService mail)
        {
            mailService = mail;
        }
        [Route("Inbox")]
        public ActionResult<Response> GetAllInBoxMails(int pointer)
        {
            var User = HttpContext.User.Claims.ToList();
            string emailid = null;
            int id = 0;
            foreach (var item in User)
            {
                if (item.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber")
                {
                    id = Convert.ToInt32(item.Value);
                }
                if (item.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                {
                    emailid = item.Value;
                }
            }
            if (id != 0 && emailid != null)
            {
                return mailService.GetInboxMails(id, emailid, pointer);
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
