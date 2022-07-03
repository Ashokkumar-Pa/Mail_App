using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class NewMail
    {
        [MaxLength(150)]
        public string ToEmail { get; set; }
        public int  ToId { get; set; }
        public int FromId { get; set; }
        public string FromMail { get; set; }

        public string Content { get; set; }
        [MaxLength(280)]
        public string Subject { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
