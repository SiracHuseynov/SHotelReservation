using SHotel.Business.DTOs.GuestReviewDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IGuestReviewService
    {
        Task AddAsyncGuestReview(GuestReviewCreateDTO guestReviewCreateDTO);
        void DeleteGuestReview(int id);
        void UpdateGuestReview(int id, GuestReviewUpdateDTO guestReviewUpdateDTO);
        GuestReviewGetDTO GetGuestReview(Func<GuestReview, bool>? func = null);
        List<GuestReviewGetDTO> GetAllGuestReviews(Func<GuestReview, bool>? func = null);


    }
}
