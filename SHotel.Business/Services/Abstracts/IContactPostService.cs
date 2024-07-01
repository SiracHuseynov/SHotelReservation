using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IContactPostService
    {
        Task AddAsyncContactPost(ContactPost contactPost);
        void DeleteContactPost(int id);
        void UpdateContactPost(int id, ContactPost contactPost);
        ContactPost GetContactPost(Func<ContactPost, bool>? func = null);
        List<ContactPost> GetContactAllPosts(Func<ContactPost, bool>? func = null);
            

    }
}
