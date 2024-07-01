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
    public class BasketItemService : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;

        public BasketItemService(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }

        public async Task AddAsyncBasketItem(BasketItem basketItem)
        {
            await _basketItemRepository.Add(basketItem);
            await _basketItemRepository.CommitAsync();
        }

        public void DeleteBasketItem(int id, string userId)
        {
            var existBasketItem = _basketItemRepository.Get(x => x.RoomId == id && x.AppUserId == userId); 

            if (existBasketItem == null)
                throw new EntityNotFoundException("Basket Item tapilmadi!");

            _basketItemRepository.Delete(existBasketItem);
            _basketItemRepository.Commit();
        }

        public List<BasketItem> GetAllBasketItems(Func<BasketItem, bool>? func = null)
        {
            return _basketItemRepository.GetAll(func, "Room");
        }

        public BasketItem GetBasketItem(Func<BasketItem, bool>? func = null)
        {
            return _basketItemRepository.Get(func, "Room");
        }

        public void UpdateBasketItem(int id, BasketItem newBasketItem)
        {
            var existBasketItem = _basketItemRepository.Get(x => x.Id == id);

            if (existBasketItem == null)
                throw new EntityNotFoundException("Basket item tapilmadi!");

            existBasketItem.IsDeleted = newBasketItem.IsDeleted;
            existBasketItem.RoomId = newBasketItem.RoomId;
            existBasketItem.AppUserId = newBasketItem.AppUserId;
            existBasketItem.DayCount = newBasketItem.DayCount;

            _basketItemRepository.Commit();
        }
    }
}
