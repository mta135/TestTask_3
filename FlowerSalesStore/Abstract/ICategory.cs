using FlowerSalesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Abstract
{
    public interface ICategory
    {
        IEnumerable<Category> Categories { get; }
    }
}
