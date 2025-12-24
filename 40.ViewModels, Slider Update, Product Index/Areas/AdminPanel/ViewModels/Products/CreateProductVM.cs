using Front_To_Back_.Models;
using Microsoft.Build.Framework;

public class CreateProductVM
{
    public string Name { get; set; }

    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public string SKU { get; set; }

    [Required]
    
    public int CategoryId { get; set; }

    public List<int>? TagIds { get; set; }
    public List<Category> Categories { get; set; }

    public List<Tag>? Tags { get; set; }

}