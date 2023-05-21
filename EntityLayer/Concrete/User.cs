using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User : BaseEntity
    {
        public Guid Guid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string? Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordHashKey { get; set; }
        public string? Token { get; set; }
        public int UserType { get; set; } = 1;
    }
}
