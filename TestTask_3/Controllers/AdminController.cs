using System.Collections.Generic;
using System.Linq;
using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
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
            List<ProductViewModel> model = MapProductToProductViewModel.Instance.ProducToProductViewModel(repository.Products);
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

        //[HttpGet]
        //public IActionResult EditCategory(int CategoryId)
        //{
        //    Category category = categoryRepository.Categories.Where(c => c.Id == CategoryId).FirstOrDefault();
        //    CategoryViewModel categoryView =
        //        MapCategoryToCategoryViewModel.Instance.CategoryToCategoryVIewModel(category);
        //    return View(categoryView);
        //}


        //[HttpPost]
        //public IActionResult EditCategory(CategoryViewModel categoryViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        categoryRepository.SaveCategory(categoryViewModel);
        //    }
        //    return RedirectToAction("Product/List");
        //}
    }
}
