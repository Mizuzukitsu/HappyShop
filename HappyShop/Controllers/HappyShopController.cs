using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyShop.Interface;
using HappyShop.Model;
using HappyShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace HappyShop.Controllers
{
    public class HappyShopController : Controller
    {
        private readonly IHappyShopService _happyShopService;

        public HappyShopController(IHappyShopService happyShopService)
        {
            _happyShopService = happyShopService;
        }
        public async Task<IActionResult> AddPet()
        {
            var pets = await _happyShopService.GetIncompleteItemsAsync();

            var model = new PetViewModel()
            {
                PetsList = pets
            };
            
            return View(model);
        }

        //[ValidateAntiForgeryToken]
        public /*async Task<IActionResult>*/ IActionResult NewPet(Pet newPet)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("AddPet");
            //}

            //var successful = await _happyShopService.NewPetAsync(newPet.Name, newPet.Gender, newPet.Type, newPet.Age, newPet.Price);
            //if (!successful)
            //{
            //    return BadRequest("Could not add item.");
            //}

            //return RedirectToAction("AddPet");

            _happyShopService.NewPetAsync(newPet.Name, newPet.Gender, newPet.Type, newPet.Age, newPet.Price);

            return View();
        }
    }
}