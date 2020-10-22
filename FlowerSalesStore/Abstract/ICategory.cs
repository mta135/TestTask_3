using FlowerSalesStore.Domain.Entities;
using FlowerSalesStore.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Abstract
{
    public interface ICategory
    {
        IEnumerable<Category> Categories { get; }
       // void SaveCategory(CategoryViewModel categoryView);
    }

}
