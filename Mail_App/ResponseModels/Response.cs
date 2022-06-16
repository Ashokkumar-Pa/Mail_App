using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class Response
    {
        public string Messege { get; set; }
        public object data { get; set; }
        public bool Status { get; set; }
    }
}
