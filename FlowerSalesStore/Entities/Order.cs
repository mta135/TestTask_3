using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Entities
{
    public class Order
    {
        [BindNever]
        public List<CartLine> Lines { get; set; }
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Comment { get; set; }

        public bool GiftWrap { get; set; }
    }
}
