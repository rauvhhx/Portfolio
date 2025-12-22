namespace Front_To_Back_.Areas.AdminPanel.ViewModels
{
    public class SliderCreateVM
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public IFormFile Photo { get; set; }
    }
}
