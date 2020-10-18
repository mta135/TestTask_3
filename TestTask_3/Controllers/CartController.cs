using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSaleStore.WebUI.Infrastructure;
using FlowerSaleStore.WebUI.Models;
using FlowerSaleStore.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSaleStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository repository;
        private readonly Cart cart;
        public CartController(IProductRepository repository, Cart cartSevice)
        {
            this.repository = repository;
            cart = cartSevice;
        }
        public ViewResult Index(string returnUrl)
        {
            CartIndexViewModel model = new CartIndexViewModel
            {
              //  Cart = GetCart(),
                Cart = cart,
                RetrunUrl = returnUrl
            };
            return View(model);
        }

        public RedirectToActionResult AddToCart(int Id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                //Cart cart = GetCart();
                cart.AddItem(product, 1);
                //SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                //Cart cart = GetCart();
                cart.RemoveLine(product);
                //SaveCart(cart);
            }
                
            return RedirectToAction("Index", new { returnUrl });
        }





        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
