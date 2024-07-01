using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using SHotel.Business.DTOs.RoomDTOs;
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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IRoomImageRepository _roomImageRepository;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, IWebHostEnvironment env, IRoomImageRepository roomImageRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _env = env;
            _roomImageRepository = roomImageRepository;
        }

        public async Task AddAsyncRoom(RoomCreateDTO roomCreateDTO)
        {
            if (roomCreateDTO.RoomPosterImageFile == null)
                throw new EntityNotFoundException("File olmalidir!");

            Room room = _mapper.Map<Room>(roomCreateDTO);

            RoomImage roomImage = new RoomImage()
            {
                Room = room,
                ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\rooms", roomCreateDTO.RoomPosterImageFile),
                IsPoster = true
            };

            await _roomImageRepository.Add(roomImage);

            foreach (var item in roomCreateDTO.RoomDetailImageFiles)
            {
                RoomImage image = new RoomImage()
                {
                    Room = room,
                    ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\rooms", item),
                    IsPoster = false
                };
                await _roomImageRepository.Add(image);
            }

            await _roomRepository.Add(room);
            await _roomRepository.CommitAsync();
        }

        public void DeleteRoom(int id)
        {
            var existRoom = _roomRepository.Get(x => x.Id == id);

            if (existRoom == null)
                throw new EntityNotFoundException("Room not found");

            var existtImage = _roomImageRepository.GetAll(x => x.RoomId == id);
            if (existtImage == null) throw new EntityNotFoundException("RoomImage not found");

            foreach (var item in existtImage)
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\rooms", item.ImageUrl);
            }

            _roomRepository.Delete(existRoom);
            _roomRepository.Commit();
        }

        public List<RoomGetDTO> GetAllRooms(Func<Room, bool>? func = null)
        {
            var rooms = _roomRepository.GetAll(func, "Bed", "RoomImages", "Reservations");

            List<RoomGetDTO> roomDtos = _mapper.Map<List<RoomGetDTO>>(rooms);

            return roomDtos;
        }

        public RoomGetDTO GetRoom(Func<Room, bool>? func = null)
        {
            var room = _roomRepository.Get(func, "Bed", "RoomImages", "Reservations"); 

            RoomGetDTO roomDtos = _mapper.Map<RoomGetDTO>(room);

            return roomDtos;
        }

   

        public void UpdateRoom(int id, RoomUpdateDTO roomUpdateDTO)
        {
            var oldRoom = _roomRepository.Get(x => x.Id == id, "RoomImages");

            if (oldRoom == null)
                throw new EntityNotFoundException("Room tapilmadi");

            Room room = _mapper.Map<Room>(roomUpdateDTO);

            foreach (var imgd in oldRoom.RoomImages.Where(bi => !room.RoomImageIds.Contains(bi.Id) && bi.IsPoster != true))
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\rooms", imgd.ImageUrl);
            }

            oldRoom.RoomImages.RemoveAll(bi => !room.RoomImageIds.Contains(bi.Id) && bi.IsPoster != true);

            if (roomUpdateDTO.RoomDetailImageFiles != null || roomUpdateDTO.RoomPosterImageFile != null)
            {

                if (roomUpdateDTO.RoomDetailImageFiles is not null)
                {
                    foreach (var image in roomUpdateDTO.RoomDetailImageFiles)
                    {
                        if (image.ContentType != "image/png")
                            throw new FileContentTypeException("File formati png olmalidir!");
                    }
                }

                if (roomUpdateDTO.RoomPosterImageFile is not null)
                {
                    if (roomUpdateDTO.RoomPosterImageFile.ContentType != "image/png")
                        throw new FileContentTypeException("File formati png olmalidir!");
                }


                //oldRoom = _mapper.Map(roomUpdateDTO, oldRoom);

                if (roomUpdateDTO.RoomPosterImageFile is not null)
                {

                    foreach (var imgd in oldRoom.RoomImages.Where(x => x.IsPoster == true))
                    {
                        Helper.DeleteFile(_env.WebRootPath, @"uploads\rooms", imgd.ImageUrl);
                    }

                    oldRoom.RoomImages.Remove(oldRoom.RoomImages.Where(x => x.IsPoster == true).FirstOrDefault());

                    RoomImage roomImage = new RoomImage()
                    {
                        Room = oldRoom,
                        ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\rooms", roomUpdateDTO.RoomPosterImageFile),
                        IsPoster = true
                    };


                    oldRoom.RoomImages.Add(roomImage);
                }




                if (roomUpdateDTO.RoomDetailImageFiles is not null)
                {
                    foreach (var item in roomUpdateDTO.RoomDetailImageFiles)
                    {



                        RoomImage image = new RoomImage()
                        {
                            Room = oldRoom,
                            ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\rooms", item),
                            IsPoster = false
                        };


                        oldRoom.RoomImages.Add(image);


                    }
                }

            }




            oldRoom.BedId = roomUpdateDTO.BedId;
            oldRoom.Title = roomUpdateDTO.Title;
            oldRoom.Description = roomUpdateDTO.Description;
            oldRoom.Price = roomUpdateDTO.Price;
            oldRoom.PersonCount = roomUpdateDTO.PersonCount;
            oldRoom.Size = roomUpdateDTO.Size;
            oldRoom.View = roomUpdateDTO.View;
            oldRoom.IsAvailable = roomUpdateDTO.IsAvailable;
            oldRoom.IsDeleted = roomUpdateDTO.IsDeleted;
            oldRoom.DiscountPercent = roomUpdateDTO.DiscountPercent;

            _roomRepository.Commit();

        }
    }
}
