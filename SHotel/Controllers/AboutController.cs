using Microsoft.AspNetCore.Mvc;
using SHotel.Business.Services.Abstracts;
using SHotel.ViewModels;

namespace SHotel.Controllers
{
    public class AboutController : Controller
    {
        private readonly IWorkerService _workerService;

        public AboutController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public IActionResult Index()
        {
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                Workers = _workerService.GetAllWorkers().Where(x=> x.IsDeleted == false).ToList()
            };
            return View(aboutViewModel);
        }
    }
}
