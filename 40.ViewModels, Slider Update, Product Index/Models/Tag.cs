namespace Front_To_Back_.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; }

    }
}
