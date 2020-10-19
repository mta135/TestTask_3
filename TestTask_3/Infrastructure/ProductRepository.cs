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



        public void SaveProduct(Product product)
        {
            try
            {
                if (product.Id == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    Product dbEntry = context.Products.FirstOrDefault(p => p.Id == product.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = product.Name;
                        dbEntry.Description = product.Description;
                        dbEntry.Price = product.Price;
                        //dbEntry.Category = product.Category;
                    }
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string exceptions = ex.ToString();
            }
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.Id == productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

