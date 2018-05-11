using HappyShop.Data;
using HappyShop.Interface;
using HappyShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyShop.Services
{
    public class HappyShopService : IHappyShopService
    {
        private readonly ApplicationDbContext _context;

        public HappyShopService(ApplicationDbContext context)
        {
            _context = context;
        }

        public /*async Task<bool>*/void NewPetAsync(string name, string gender, string type, int age, decimal price)
        {
            using (var db = _context)
            {
                var pet = new Pet()
                {
                    Name = name,
                    Gender = gender,
                    Type = type,
                    Age = age,
                    Price = price
                };
                //var saveResult = await db.SaveChangesAsync();
                //return saveResult == 1;
                db.Pets.Add(pet);
                db.SaveChanges();
            }
        }

        public async Task<Pet[]> GetIncompleteItemsAsync()
        {
            return await _context.Pets.ToArrayAsync();
        }
    }
}
