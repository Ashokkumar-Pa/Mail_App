using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class UserTokenModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
    }
}
