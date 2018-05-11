using HappyShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyShop.Interface
{
    public interface IHappyShopService
    {
        Task<Pet[]> GetIncompleteItemsAsync();

        void NewPetAsync(string name, string gender, string type, int age, decimal price);
    }
}
