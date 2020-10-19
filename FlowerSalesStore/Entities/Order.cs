using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowerSalesStore.Domain.Entities
{
    public class Order
    {
        [BindNever]
        public List<CartLine> Lines { get; set; }
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public string Comment { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }


    }
}
