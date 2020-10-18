using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSaleStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FlowerSaleStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder repository;
        private readonly Cart cart;

        public OrderController(IOrder repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }


        public IActionResult Checkout()
        {
            Order order = new Order();
            return View(order);
        }
    }
}
