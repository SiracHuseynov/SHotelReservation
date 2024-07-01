using Microsoft.AspNetCore.Mvc;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using System.Net.Mail;
using System.Net;
using SHotel.Business.Extensions;
using SHotel.Business.Services.Concretes;
using SHotel.Business.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace SHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ContactInfoController : Controller
    {
        private readonly IContactPostService _contactPost;

        public ContactInfoController(IContactPostService contactPost)
        {
            _contactPost = contactPost;
        }

        public IActionResult Index(int page = 1)
        {
            var contacts = _contactPost.GetContactAllPosts(x => x.IsDeleted == false);

            if (page <= 0 || page > (double)Math.Ceiling((double)contacts.Count / 6))
            {
                return RedirectToAction("Index");

            }

            var paginatedDatas = PaginatedList<ContactPost>.Create(contacts, 6, page); 

            return View(paginatedDatas);
        }

        public IActionResult Reply(int id)
        {
            var existContac = _contactPost.GetContactPost(x => x.Id == id);
            if (existContac == null) return NotFound();

            return View(existContac);
        }
        [HttpPost]
        public IActionResult Reply(ContactPost contactPost)
        {
            try
            {
                _contactPost.UpdateContactPost(contactPost.Id, contactPost);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("tu6uvrrlv@code.edu.az", "SHotel");
            mailMessage.To.Add(new MailAddress($"{contactPost.Email}"));
            mailMessage.Subject = $"{contactPost.Name} to reply";
            mailMessage.Body = "Question: " + $"\"{contactPost.Comment}\" " + "-" +  " ANSWER:" +  contactPost.Answer;  
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("tu6uvrrlv@code.edu.az", "vaaqwscossjbamcg");
            smtpClient.Send(mailMessage);


            return RedirectToAction("Index");
        }
    }
}
