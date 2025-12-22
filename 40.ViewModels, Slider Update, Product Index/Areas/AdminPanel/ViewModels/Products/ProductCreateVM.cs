public class ProductCreateVM
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; } 
    public IFormFile MainPhoto { get; set; } 
    
}