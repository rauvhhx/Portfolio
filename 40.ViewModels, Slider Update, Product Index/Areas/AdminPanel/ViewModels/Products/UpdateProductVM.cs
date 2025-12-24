using Front_To_Back_.Models;
using System.ComponentModel.DataAnnotations;

namespace Front_To_Back_.Areas.AdminPanel.ViewModels.Products
{
    public class UpdateProductVM
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string SKU { get; set; }

        [Required]

        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; }
        public List<Category> Categories { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
