using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerSalesStore.Domain.Abstract
{
    public interface IOrder
    {
        IQueryable<Order> Orders { get; }
        //  void SaveOrder(Order order);
        void SaveOrder(List<OrderViewModel> orderViewModelsList);
    }
}
