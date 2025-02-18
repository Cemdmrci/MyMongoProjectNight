using Microsoft.AspNetCore.Mvc;

namespace MyMongoProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
