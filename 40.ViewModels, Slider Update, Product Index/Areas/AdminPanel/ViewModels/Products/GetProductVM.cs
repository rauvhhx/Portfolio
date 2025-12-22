using Front_To_Back_.Models;

namespace Front_To_Back_.Areas.AdminPanel.ViewModels.Products
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }

        public string ImageURL { get; set; }
    }
}
