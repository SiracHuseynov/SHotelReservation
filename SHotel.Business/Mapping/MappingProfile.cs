using AutoMapper;
using SHotel.Business.DTOs.AdventureCategoryDTOs;
using SHotel.Business.DTOs.AdventureDTOs;
using SHotel.Business.DTOs.BedDTOs;
using SHotel.Business.DTOs.EatCategoryDTOs;
using SHotel.Business.DTOs.EatDTOs;
using SHotel.Business.DTOs.FeatureDTOs;
using SHotel.Business.DTOs.GuestReviewDTOs;
using SHotel.Business.DTOs.PositionDTOs;
using SHotel.Business.DTOs.ReservationDTOs;
using SHotel.Business.DTOs.RoomDTOs;
using SHotel.Business.DTOs.SettingDTOs;
using SHotel.Business.DTOs.SliderDTOs;
using SHotel.Business.DTOs.WorkerDTOs;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SliderCreateDTO, Slider>().ReverseMap();
            CreateMap<Slider, SliderGetDTO>().ReverseMap();

            CreateMap<FeatureCreateDTO, Feature>().ReverseMap();
            CreateMap<Feature, FeatureGetDTO>().ReverseMap();

            CreateMap<GuestReviewCreateDTO, GuestReview>().ReverseMap();
            CreateMap<GuestReview, GuestReviewGetDTO>().ReverseMap();

            CreateMap<PositionCreateDTO, Position>().ReverseMap();  
            CreateMap<Position, PositionGetDTO>().ReverseMap();

            CreateMap<WorkerCreateDTO, Worker>().ReverseMap();
            CreateMap<Worker, WorkerGetDTO>().ReverseMap();

            CreateMap<EatCategoryCreateDTO, EatCategory>().ReverseMap();
            CreateMap<EatCategory, EatCategoryGetDTO>().ReverseMap();

            CreateMap<EatCreateDTO, Eat>().ReverseMap();
            CreateMap<Eat, EatGetDTO>().ReverseMap();

            CreateMap<BedCreateDTO, Bed>().ReverseMap();
            CreateMap<Bed, BedGetDTO>().ReverseMap();

            CreateMap<RoomCreateDTO, Room>().ReverseMap();
            CreateMap<Room, RoomGetDTO>().ReverseMap();
            CreateMap<RoomUpdateDTO, Room>().ReverseMap();

            CreateMap<ReservationCreateDTO, Reservation>().ReverseMap();
            CreateMap<Reservation, ReservationGetDTO>().ReverseMap();

            CreateMap<SettingCreateDTO, Setting>().ReverseMap();
            CreateMap<Setting, SettingGetDTO>().ReverseMap();


            CreateMap<AdventureCategoryCreateDTO, AdventureCategory>().ReverseMap();
            CreateMap<AdventureCategory, AdventureCategoryGetDTO>().ReverseMap();
            CreateMap<AdventureCategoryUpdateDTO, AdventureCategory>().ReverseMap();

            CreateMap<AdventureCreateDTO, Adventure>().ReverseMap();
            CreateMap<Adventure, AdventureGetDTO>().ReverseMap();
            CreateMap<AdventureUpdateDTO, Adventure>().ReverseMap();


        }
    }
}
