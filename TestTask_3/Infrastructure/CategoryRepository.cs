using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.Infrastructure
{
    public class CategoryRepository : ICategory
    {
        private readonly FlowerSaleStoreDbContext context;

        public CategoryRepository(FlowerSaleStoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Categories.ToList();
            }
        }

        //public void SaveCategory(CategoryViewModel categoryView)
        //{
        //    try
        //    {
        //        Category dbEntry = context.Categories.FirstOrDefault(c => c.Id == categoryView.Id);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.Name = categoryView.Name;
        //            dbEntry.Description = categoryView.Description;
        //        }
        //        context.SaveChanges();
        //    } catch(Exception ex)
        //    {
        //        string exception = ex.ToString();
        //    }
        //}
    }
}
