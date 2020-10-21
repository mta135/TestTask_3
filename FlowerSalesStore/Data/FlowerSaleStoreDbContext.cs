using FlowerSalesStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Data
{
    public class FlowerSaleStoreDbContext : DbContext
    {
        public FlowerSaleStoreDbContext(DbContextOptions<FlowerSaleStoreDbContext> options) : base(options) { }
        
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
