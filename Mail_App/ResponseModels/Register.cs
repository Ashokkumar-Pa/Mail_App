using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.ResponseModels
{
    public class Register
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string PrimaryAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmationPassword { get; set; }
        public string TemporaryAddress { get; set; }
        [Required]
        public int PinCode { get; set; }

    }
}
