using Microsoft.AspNetCore.Mvc;

namespace SHotel.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
