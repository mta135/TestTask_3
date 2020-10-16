﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } // ?

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }
    }
}
