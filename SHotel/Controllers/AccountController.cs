using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHotel.Business.Enums;
using SHotel.Core.Models;
using SHotel.Data.DAL;
using SHotel.ViewModels;
using System.Net;
using System.Net.Mail;

namespace SHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _appDbContext;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterVm memberRegisterVm) 
        {
            if (!ModelState.IsValid)
                return View();

            var appUser = await _userManager.FindByNameAsync(memberRegisterVm.Username);

            if (appUser != null)
            {
                ModelState.AddModelError("Username", "Username already exist");
                return View();
            }

            appUser = await _userManager.FindByEmailAsync(memberRegisterVm.Email);

            if (appUser != null)  
            {
                ModelState.AddModelError("Email", "Email already exist");
                return View();
            }

             appUser = new()
            {
                Name = memberRegisterVm.Name,
                Surname = memberRegisterVm.Surname,
                UserName = memberRegisterVm.Username,
                Email = memberRegisterVm.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, memberRegisterVm.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); 
                }
                return View(memberRegisterVm);
            }

            await _userManager.AddToRoleAsync(appUser, RoleEnum.Member.ToString());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            var url = Url.Action(nameof(VerifyEmail), "Account", new {email = appUser.Email, token},
                Request.Scheme, Request.Host.ToString());

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("tu6uvrrlv@code.edu.az", "VerifyEmail");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Verify Email";
            string body = string.Empty;

            using (StreamReader streamReader = new StreamReader("wwwroot/Template/htmlpage.html"))
            {
                body = streamReader.ReadToEnd();
            }

            mailMessage.Body = body.Replace("{{link}}", url);
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential("tu6uvrrlv@code.edu.az", "vaaqwscossjbamcg");
            smtpClient.Send(mailMessage);


            return RedirectToAction("Login", "Account"); 
        }

        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (appUser == null) return NotFound();
            await _userManager.ConfirmEmailAsync(appUser, token);
            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home"); 
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); 
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginVm memberLoginVm, string? ReturnUrl)   
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.FindByEmailAsync(memberLoginVm.UsernameOrEmail);
            if(user == null)
            {
                user = await _userManager.FindByNameAsync(memberLoginVm.UsernameOrEmail);
                if(user == null)
                {
                    ModelState.AddModelError("", "Username veya email veya password sehvdir!");
                    return View(memberLoginVm);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user, memberLoginVm.Password, memberLoginVm.RememberMe, true);

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("Verify", "Zehmet olmasa Emailinizi Verify edin!"); 
                return View();
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabiniz bloklanib!");
                return View(memberLoginVm);
            }

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Username veya email veya password sehvdir!");
                return View(memberLoginVm);
            }

            await _signInManager.SignInAsync(user, memberLoginVm.RememberMe);

            if(ReturnUrl != null)
            {
                return Redirect(ReturnUrl); 
            }

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var item in roles)
            {
                if(item == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new {area="Admin"}); 
                }
            }

           

            return RedirectToAction("Index", "Home"); 
        }

        public async Task<IActionResult> CreateRoles()
        {
            foreach(var role in Enum.GetValues(typeof(RoleEnum)))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString()});
            }

            return Content("Roles created!"); 
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {

            AppUser appUser = await _userManager.FindByEmailAsync(forgetPasswordViewModel.appUser.Email);

            if(appUser == null)
            {
                ModelState.AddModelError("Error", "Bele bir Email yoxdur!");
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            var link = Url.Action(nameof(ResetPassword), "Account", new {email=appUser.Email,
            token}, Request.Scheme, Request.Host.ToString()); 

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("tu6uvrrlv@code.edu.az", "SHotel");       
            mailMessage.To.Add(new MailAddress(appUser.Email));  
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = $"<a href={link}>Please Click Here</a>";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("tu6uvrrlv@code.edu.az", "vaaqwscossjbamcg");

            smtpClient.Send(mailMessage);


            return RedirectToAction("Index", "Home");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string token, string email, ForgetPasswordViewModel forgetPasswordViewModel)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View();

            await _userManager.ResetPasswordAsync(user, token, forgetPasswordViewModel.Password);


            return RedirectToAction("Login", "Account");  
        }


        public async Task<IActionResult> Profile()
        {
            AppUser appUser = null;

            if(HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            }

            List<Order> orders = await _appDbContext.Orders
                                                    .Where(x=> x.AppUserId == appUser.Id)
                                                    .ToListAsync();


            return View(orders);


        }



    }
}
