using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using FlowerSaleStore.WebUI.Infrastructure;
using FlowerSaleStore.WebUI.Models;
using FlowerSaleStore.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FlowerSaleStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder repository;
        private readonly Cart cart;
        private readonly IMailService mailService;

        public OrderController(IOrder repository, Cart cart, IMailService mailService)
        {
            this.repository = repository;
            this.cart = cart;
            this.mailService = mailService;
        }


        public IActionResult Checkout()
        {
            Order order = new Order();
            return View(order);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            User user = HttpContext.Session.GetComplexData<User>("User");
            if ((user != null) && (!string.IsNullOrEmpty(user.Login)) && (!string.IsNullOrEmpty(user.Password)))
            {
                if (cart.Lines.Count() == 0)
                {
                    ModelState.AddModelError("", "Sorry, your cart is empty!");
                }
                if (ModelState.IsValid)
                {
                    int UserId = 0;
                    if (user != null)
                        UserId = user.Id;
                    List<OrderViewModel> orderViewModelsList = new List<OrderViewModel>();
                    order.Lines = cart.Lines.ToList();
                    foreach (var item in order.Lines)
                    {
                        OrderViewModel orderViewModel = new OrderViewModel
                        {
                            ProductId = item.Product.Id,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            UserId = UserId
                        };
                        orderViewModelsList.Add(orderViewModel);
                    }
                    repository.SaveOrder(orderViewModelsList);

                    //if(!string.IsNullOrEmpty(user.Email))
                    //    SendMailNotification(user.Email);
                        
                    return RedirectToAction(nameof(Completed));
                }
                else
                {
                    return View(order);
                }
            }
            else
            {
                return RedirectToAction(nameof(Info));
            }
        }

        [HttpGet]
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

        [HttpGet]
        public ViewResult Info()
        {
            return View();
        }


        private void SendMailNotification(string email)
        {
            MailRequest mailRequest = new MailRequest
            {
                ToEmail = email,
                Subject = "Flower Sale Store",
                Body = "Your order is procesed."
            };
            mailService.SendEmail(mailRequest);
        }
    }
}
