using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string NAME { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
