using Microsoft.AspNetCore.Mvc;

namespace SHotel.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
