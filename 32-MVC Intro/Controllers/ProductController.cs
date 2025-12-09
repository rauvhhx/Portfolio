using Microsoft.AspNetCore.Mvc;

namespace MVCIntro.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
