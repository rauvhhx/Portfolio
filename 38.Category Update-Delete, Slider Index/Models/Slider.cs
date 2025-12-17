namespace FrontToBack.Models
{
    public class Slider:BaseEntity
    {
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public int Order { get; set; }

    }
}
