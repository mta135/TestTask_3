using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSalesStore.Domain.Entities;
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
    }
}
