using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly ICategory repository;
        public NavigationMenuViewComponent(ICategory repository)
        {
            this.repository = repository;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            IEnumerable<Category> categories = repository.Categories;
            List<string> categoryNameList = new List<string>();
            foreach (Category category in categories)
                categoryNameList.Add(category.Name);
            return View(categoryNameList);
        }

        //public string Invoke()
        //{
        //    return "Hello from the Nav View Components";
        //}
    }
}
