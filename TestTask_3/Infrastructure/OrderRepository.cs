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
    public class OrderRepository : IOrder
    {
        private readonly FlowerSaleStoreDbContext context;
        public OrderRepository(FlowerSaleStoreDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> Orders
        {
            get
            {
                return context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);
            }
        }

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
