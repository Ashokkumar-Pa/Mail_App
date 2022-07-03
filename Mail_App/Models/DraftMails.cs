using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Models
{
    public class DraftMails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("GetFromUser")]

        [Required]
        public int FromUserId { get; set; }

        public virtual UserProfile GetFromUser { get; set; }

        //[Required]
        [ForeignKey("GetToUser")]

        public int? ToUserId { get; set; }
        public virtual UserProfile GetToUser { get; set; }

        [MaxLength(280)]
        public string Subject { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public DateTime LastSaveDateTime { get; set; }
    }
}
