using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
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
          
                // there is something wrong with the data values
               // return View(product);
           
        }

        public IActionResult Create()
        {
            return View("Edit", new Product());
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
