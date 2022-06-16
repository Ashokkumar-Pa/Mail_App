using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Models
{
    public class UserPassword
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }
        [Required]
        [Range(8, 30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime LastChangesOn { get; set; }
    }
}
