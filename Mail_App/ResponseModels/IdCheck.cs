using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class IdCheck
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    [BindProperties]
    public class PasswordCheck
    {
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
