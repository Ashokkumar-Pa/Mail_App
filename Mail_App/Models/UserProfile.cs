using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string PrimaryAddress { get; set; }
        public string TemporaryAddress { get; set; }
        [Required]
        public int PinCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastChangesOn { get; set; }


        //public virtual ICollection<OnetoOneMail> OnetoOneMails { get; set; }
    }
}
