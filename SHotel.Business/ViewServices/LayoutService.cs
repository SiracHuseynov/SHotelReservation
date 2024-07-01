using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.ViewServices
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISettingService _settingService;
        public LayoutService(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, ISettingService settingService)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _settingService = settingService;
        }

        public async Task<List<Setting>> GetSetting()
        {
            var settings = _context.Settings.ToList();
            return settings;
        }

        public async Task<AppUser> GetUserData() 
        {
            if(_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
            }
            return null;
        }
    }
}
