using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using FlowerSaleStore.WebUI.Models;
using FlowerSaleStore.WebUI.ViewModels;
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

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                List<OrderViewModel> orderViewModelsList = new List<OrderViewModel>();
                order.Lines = cart.Lines.ToList();
                var orderItem = cart.Lines.ToList(); // for testing latter need to remove
                
                foreach(var item in order.Lines)
                {
                    var value = item.Id;
                    OrderViewModel orderViewModel = new OrderViewModel
                    {
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    orderViewModelsList.Add(orderViewModel);
                }
                repository.SaveOrder(orderViewModelsList);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        [HttpGet]
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
