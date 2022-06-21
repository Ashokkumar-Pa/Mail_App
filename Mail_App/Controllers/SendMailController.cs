using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
