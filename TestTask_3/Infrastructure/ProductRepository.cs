using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSalesStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private FlowerSaleStoreDbContext context;
 
        public ProductRepository(FlowerSaleStoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products
        {

            get
            {
                return context.Products.Include(p => p.Category);
            }
            
        }
    }
}
