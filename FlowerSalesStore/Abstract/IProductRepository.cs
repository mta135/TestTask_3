using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        void SaveProduct(ProductViewModel productViewModel);

        Product DeleteProduct(int productID);
    }
}
