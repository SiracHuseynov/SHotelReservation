using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHotel.Business.ViewServices;
using SHotel.Core.Models;
using SHotel.Data.DAL;

namespace SHotel.Controllers
{
    public class ComingSoonController : Controller
    {
        private readonly AppDbContext _context;

        public ComingSoonController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<List<Setting>> GetSetting()
        {
            var settings = _context.Settings.ToList();
            return settings;
        }
    }
}
