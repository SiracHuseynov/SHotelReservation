using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SHotel.Business.DTOs.GuestReviewDTOs;
using SHotel.Business.Exceptions;
using SHotel.Business.Extensions;
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
    public class GuestReviewService : IGuestReviewService
    {
        private readonly IGuestReviewRepository _guestReviewRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public GuestReviewService(IGuestReviewRepository guestReviewRepository, IWebHostEnvironment env, IMapper mapper)
        {
            _guestReviewRepository = guestReviewRepository;
            _env = env;
            _mapper = mapper;
        }

        public async Task AddAsyncGuestReview(GuestReviewCreateDTO guestReviewCreateDTO)
        {
            if (guestReviewCreateDTO.ImageFile == null)
                throw new ImageFileNotFoundException("Image olmalidir!");

            GuestReview guestReview = _mapper.Map<GuestReview>(guestReviewCreateDTO);

            guestReview.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\guestReviews", guestReviewCreateDTO.ImageFile);

            await _guestReviewRepository.Add(guestReview);
            await _guestReviewRepository.CommitAsync();

        }

        public void DeleteGuestReview(int id)
        {
            var existGuestReview = _guestReviewRepository.Get(x => x.Id == id);

            if (existGuestReview == null)
                throw new EntityNotFoundException("Guest Review tapilmadi!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\guestReviews", existGuestReview.ImageUrl);

            _guestReviewRepository.Delete(existGuestReview);
            _guestReviewRepository.Commit();
        }

        public List<GuestReviewGetDTO> GetAllGuestReviews(Func<GuestReview, bool>? func = null)
        {
            var guestReviews = _guestReviewRepository.GetAll(func);

            List<GuestReviewGetDTO> guestDtos = _mapper.Map<List<GuestReviewGetDTO>>(guestReviews);

            return guestDtos;
        }

        public GuestReviewGetDTO GetGuestReview(Func<GuestReview, bool>? func = null)
        {
            var guestReview = _guestReviewRepository.Get(func);

            GuestReviewGetDTO guestDto = _mapper.Map<GuestReviewGetDTO>(guestReview);

            return guestDto;
        }

        public void UpdateGuestReview(int id, GuestReviewUpdateDTO guestReviewUpdateDTO)
        {
            var oldGuestReview = _guestReviewRepository.Get(x => x.Id == id);

            if (oldGuestReview == null)
                throw new EntityNotFoundException("Guest Review tapilmadi!");

            if(guestReviewUpdateDTO.ImageFile != null)
            {
                if (guestReviewUpdateDTO.ImageFile.ContentType != "image/png")
                    throw new FileContentTypeException("Image png formatinda olmalidir!");

                Helper.DeleteFile(_env.WebRootPath, @"uploads\guestReviews", oldGuestReview.ImageUrl);

                oldGuestReview.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\guestReviews", guestReviewUpdateDTO.ImageFile);
            }

            oldGuestReview.FullName = guestReviewUpdateDTO.FullName;
            oldGuestReview.Address = guestReviewUpdateDTO.Address;
            oldGuestReview.Description = guestReviewUpdateDTO.Description;
            oldGuestReview.IsDeleted = guestReviewUpdateDTO.IsDeleted;

            _guestReviewRepository.Commit();
        }

    }
}
