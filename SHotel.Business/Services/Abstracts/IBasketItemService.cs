using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Business.Services.Abstracts
{
    public interface IBasketItemService
    {
        Task AddAsyncBasketItem(BasketItem basketItem);
        void DeleteBasketItem(int id, string userId); 
        void UpdateBasketItem(int id, BasketItem newBasketItem);
        BasketItem GetBasketItem(Func<BasketItem, bool>? func = null);
        List<BasketItem> GetAllBasketItems(Func<BasketItem, bool>? func = null);


    }
}
