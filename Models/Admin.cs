using System;
using System.ComponentModel.DataAnnotations;

namespace EmreProje.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        public Boolean isActive = false;
    }
}
