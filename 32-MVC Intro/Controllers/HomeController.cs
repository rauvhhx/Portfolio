using Microsoft.AspNetCore.Mvc;

namespace MVCIntro.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //return Content("APA102");

            //var student = new JsonResult(
            //    new
            //    {
            //        Id = 1,
            //        Name = "Elvin",
            //        Surname = "Aliyev"
            //    }
            //    );
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }


            //return id;

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
