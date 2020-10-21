using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private FlowerSaleStoreDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductRepository(FlowerSaleStoreDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
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

        public void SaveProduct(ProductViewModel productViewModel)
        {
            try
            {
                Product product = new Product();
                Category category = new Category();

                product.Name = productViewModel.Name;
                product.Description = productViewModel.Description;
                product.Price = productViewModel.Price;
                category.Name = productViewModel.CategoryName;
                category.Description = productViewModel.CategoryDescription;
                product.Category = category;
                string uniqueFileName = null;
                if (productViewModel.File != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Files");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + productViewModel.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    productViewModel.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                product.FilePath = uniqueFileName;
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
            }
        }
    }
}

