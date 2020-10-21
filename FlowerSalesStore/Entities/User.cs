using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowerSalesStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string NAME { get; set; }

        [Required(ErrorMessage = "Please enter your login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string ReturnUrl { get; set; } = "/";
    }
}
