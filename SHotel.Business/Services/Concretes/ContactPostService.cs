using SHotel.Business.Exceptions;
using SHotel.Business.Services.Abstracts;
using SHotel.Core.Models;
using SHotel.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Concretes
{
    public class ContactPostService : IContactPostService
    {
        private readonly IContactPostRepository _contactPostRepository;

        public ContactPostService(IContactPostRepository contactPostRepository)
        {
            _contactPostRepository = contactPostRepository;
        }

        public async Task AddAsyncContactPost(ContactPost contactPost)
        {
            await _contactPostRepository.Add(contactPost);
            await _contactPostRepository.CommitAsync();
        }

        public void DeleteContactPost(int id)
        {
            var existContactPost = _contactPostRepository.Get(x=> x.Id == id);
            if (existContactPost == null)
                throw new EntityNotFoundException("ContactPost movcud deyil!");

            _contactPostRepository.Delete(existContactPost);
            _contactPostRepository.Commit();
        }

        public ContactPost GetContactPost(Func<ContactPost, bool>? func = null)
        {
            return _contactPostRepository.Get(func);
        }

        public List<ContactPost> GetContactAllPosts(Func<ContactPost, bool>? func = null)
        {
            return _contactPostRepository.GetAll(func);
        }

        public void UpdateContactPost(int id, ContactPost contactPost)
        {
            var oldContact = _contactPostRepository.Get(x => x.Id == id);

            if (oldContact == null)
                throw new EntityNotFoundException("Contact movcud deyil!");

            oldContact.Name = contactPost.Name;
            oldContact.Email = contactPost.Email;
            oldContact.Comment = contactPost.Comment;
            oldContact.AnswerByUserId = contactPost.AnswerByUserId;
            oldContact.Answer = contactPost.Answer;
            oldContact.AnsweredDate = contactPost.AnsweredDate;
            oldContact.IsDeleted = contactPost.IsDeleted; 


            _contactPostRepository.Commit();
        }
    }
}
