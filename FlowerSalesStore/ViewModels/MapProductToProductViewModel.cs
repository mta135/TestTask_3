using FlowerSalesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerSalesStore.Domain.ViewModels
{
    public class MapProductToProductViewModel
    {
        private static MapProductToProductViewModel instance = null;
        private ProductViewModel reviewViewModels;
        private static readonly object padlock = new object();
        private MapProductToProductViewModel()
        {
        }

        public static MapProductToProductViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MapProductToProductViewModel();
                        }
                    }
                }
                return instance;
            }
        }
        public List<ProductViewModel> ProducToProductViewModel(IEnumerable<Product> products)
        {
            List<ProductViewModel> listOfProductViewModels = new List<ProductViewModel>();
            if (products.Count() != 0)
            {
                foreach (Product item in products)
                {
                    reviewViewModels = new ProductViewModel
                    {
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        Image = item.Image,
                        CategoryName = item.Category.Name
                    };
                    listOfProductViewModels.Add(reviewViewModels);
                }
            }
            return listOfProductViewModels;
        }

        public ProductViewModel ProducToProductViewModel(Product product)
        {
            reviewViewModels = new ProductViewModel();
            if(product != null)
            {
                reviewViewModels.Id = product.Id;
                reviewViewModels.Description = product.Description;
                reviewViewModels.CategoryName = product.Category.Name;
                reviewViewModels.Price = product.Price;
            }
            return reviewViewModels;
        }
    }
}
