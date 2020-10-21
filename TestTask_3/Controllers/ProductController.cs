using System;
using System.Collections.Generic;
using System.Linq;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSaleStore.WebUI.Models;
using FlowerSaleStore.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using FlowerSaleStore.WebUI.Infrastructure;

namespace FlowerSaleStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int pageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult List(string category, int page = 1)
        {
            User user = HttpContext.Session.GetComplexData<User>("User");
            if(user != null)
            {
                ViewBag.IsAdmin = user.IsAdmin;
            }
          
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => p.Category.Name == category ||  string.IsNullOrEmpty(category))
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    //TotalItems = repository.Products.Count()
                   TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category.Name == category).Count(),
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
