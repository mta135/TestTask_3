using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.ViewModels
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
