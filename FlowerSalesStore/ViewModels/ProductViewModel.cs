using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FlowerSalesStore.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } // ?

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public IFormFile File { get; set; }

       // public List<SelectListItem> Categories { get; set; }

    }
}
