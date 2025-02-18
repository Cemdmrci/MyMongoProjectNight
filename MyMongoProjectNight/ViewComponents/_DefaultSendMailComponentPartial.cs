using Microsoft.AspNetCore.Mvc;

namespace MyMongoProjectNight.ViewComponents
{
    public class _DefaultSendMailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

