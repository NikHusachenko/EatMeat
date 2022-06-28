using EatMeat.Database.Entities;
using EatMeat.Database.Enums;
using EatMeat.Services.MeatServices;
using EatMeat.Services.MeatServices.Models;
using EatMeat.Web.Models.Meat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EatMeat.Web.Controllers
{
    [Authorize]
    public class MeatController : Controller
    {
        private readonly IMeatService _meatService;

        public MeatController(IMeatService meatService)
        {
            _meatService = meatService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { responseMessage = "Invalid data" });
            }

            _meatService.Create(vm);
            return Ok(new { responseMessage = Url.Action("Settings", "Meat") });
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            SettingsViewModel vm = new SettingsViewModel() { Meats = await _meatService.GetAllAsync() };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id = -1)
        {
            if(!await _meatService.Delete(id))
            {
                return NotFound($"Meat with {id} not found in database");
            }
            
            return RedirectToAction("Settings", "Meat");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(long id = -1)
        {
            if(id == -1)
            {
                return NotFound($"Meat with id {id} not found in database");
            }

            DetailsViewModel vm = new DetailsViewModel() { Meat = await _meatService.GetByIdAsync(id) };
            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Types(int type = -1)
        {
            List<MeatEntity> meats = new List<MeatEntity>();
            if(type == -1)
            {
                meats = await _meatService.GetAllAsyncNotBuyed();
            }
            else
            {
                meats = await _meatService.GetByTypeNotBuyed((MeatTypes)type);
            }

            return View("ShowAll", meats);
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Sources(int source = -1)
        {
            List<MeatEntity> meats = new List<MeatEntity>();
            if(source == -1)
            {
                meats = await _meatService.GetAllAsyncNotBuyed();
            }
            else
            {
                meats = await _meatService.GetBySourceNotBuyed((MeatSource)source);
            }

            return View("ShowAll", meats);
        }

        [HttpGet]
        public async Task<IActionResult> Buy(long productId, long buyerId)
        {
            await _meatService.Buy(productId, buyerId);
            return RedirectToAction("Cart", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(long id)
        {
            await _meatService.Cancel(id);
            return RedirectToAction("Cart", "User");
        }
    }
}