using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using FlowerSaleStore.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        public void SaveOrder(List<OrderViewModel> orderViewModelsList)
        {
            try
            {
                List<Order> ordersList = new List<Order>();
                foreach (var item in orderViewModelsList)
                {
                    Order order = new Order
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Quantity * item.Price,
                        UserId = item.UserId
                    };
                    ordersList.Add(order);
                }
                context.Orders.AddRange(ordersList);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
        }
    }
}


