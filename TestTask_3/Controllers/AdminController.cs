using System.Collections.Generic;
using System.Linq;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowerSaleStore.WebUI.Controllers
{    
    public class AdminController : Controller
    {
        private readonly IProductRepository repository;
        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> model = repository.Products;
            // ProductViewModel model // it has to be done
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Product productmodel = repository.Products.FirstOrDefault(p => p.Id == Id);
            return View(productmodel);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            repository.SaveProduct(product);
            TempData["message"] = $"{product.Name} has been saved";    
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
       
        public IActionResult Create(ProductViewModel productViewModel)
        {
            repository.SaveProduct(productViewModel);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product deletedProduct = repository.DeleteProduct(id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }


    }
}
