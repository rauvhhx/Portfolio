namespace Front_To_Back_.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public Product product { get; set; }
        public Tag Tag { get; set; }
    }
}
