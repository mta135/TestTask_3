using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlowerSalesStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } // ?

        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }

        public string FilePath { get; set; }
    }
}
