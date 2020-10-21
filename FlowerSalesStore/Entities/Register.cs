using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlowerSalesStore.Domain.Entities
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Email { get; set; }
    }
}
