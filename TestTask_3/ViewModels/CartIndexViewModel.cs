using FlowerSaleStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string RetrunUrl { get; set; }
    }
}
