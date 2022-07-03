using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class Inbox
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDateTime { get; set; }
        public bool IsReaded { get; set; }

    }
}
