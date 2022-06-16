using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class IdCheck
    {
        public string Name;
        public int Id;
    }
    public class PasswordCheck
    {
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
