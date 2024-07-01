using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SHotel.Data.DAL;

namespace SHotel.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactPostService _contactPostService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ISettingService _settingService;
        private readonly AppDbContext _context;
        public ContactController(IContactPostService contactPostService, UserManager<AppUser> userManager, AppDbContext context)
        {
            _contactPostService = contactPostService;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> Index(ContactPost contactPost)
        {
            if (!ModelState.IsValid)
                return View();

            await _contactPostService.AddAsyncContactPost(contactPost);
            ModelState.Clear();


            return View();
        }


    }
}

