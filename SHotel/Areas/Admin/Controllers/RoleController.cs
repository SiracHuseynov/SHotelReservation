using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHotel.Core.Models;
using SHotel.ViewModels;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        { 
            if(string.IsNullOrEmpty(role.Name))
                return NotFound();

            await _roleManager.CreateAsync(role);

            return RedirectToAction("Index"); 
        }

        public async Task<IActionResult> Delete(IdentityRole role)
        {
            var roleGet = await _roleManager.GetRoleIdAsync(role);

            if(roleGet == null)
                return NotFound();

            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Update(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);

        //    if (user == null)
        //        return NotFound();

        //    AdminRoleViewModel roleViewModel = new AdminRoleViewModel();
        //    roleViewModel.UserRoles = await _userManager.GetRolesAsync(user);
        //    roleViewModel.Roles = _roleManager.Roles.ToList();
        //    roleViewModel.User = user;


        //    return View(roleViewModel);

        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(string id, List<string> roles)
        //{
        //    AppUser user = await _userManager.FindByIdAsync(id);
        //    var userRoles = await _userManager.GetRolesAsync(user);
        //    await _userManager.RemoveFromRolesAsync(user, userRoles);
        //    await _userManager.AddToRolesAsync(user, roles);

        //    return RedirectToAction("Index", "User");


        //}


        [HttpGet]
        public async Task<IActionResult> Update(string id)     
        { 
            var user = await _userManager.FindByIdAsync(id); 
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.ToListAsync();

            var model = new AdminRoleViewModel
            {
                User = user,
                Roles = allRoles,
                UserRoles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, List<string> roles)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var resultRemove = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!resultRemove.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove existing roles.");
                return View();
            }

            var resultAdd = await _userManager.AddToRolesAsync(user, roles);
            if (!resultAdd.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add new roles.");
                return View();
            }

            return RedirectToAction("Index", "User");
        }


    }
}
