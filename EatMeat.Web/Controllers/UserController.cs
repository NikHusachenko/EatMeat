using EatMeat.Database.Entities;
using EatMeat.Services.MeatServices;
using EatMeat.Services.UserServices;
using EatMeat.Services.UserServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EatMeat.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMeatService _meatService;

        public UserController(IUserService userService,
            IMeatService meatService,
            ICurrentUserService currentUserService)
        {
            _userService = userService;
            _meatService = meatService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody]SignInViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { responseMessage = "Invalid data" });
            }

            if(!await _userService.SignIn(vm))
            {
                return BadRequest(new { responseMessage = "No found" });
            }

            return Ok(new { responseMessage = Url.Action("Index", "Home") });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            _userService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { responseMessage = "Invalid data" });
            }

            if(!await _userService.SignUp(vm))
            {
                return BadRequest(new { responseMessage = "Was created" });
            }

            return Ok(new {responseMessage = Url.Action("Index", "Home") });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            UserEntity userEntity = await _userService.GetByIdAsync(int.Parse(_currentUserService.Id.ToString()));
            return View(userEntity.Meats);
        }

        [HttpGet]
        public async Task<IActionResult> BuyAll()
        {
            UserEntity userEntity = await _userService.GetByIdAsync(long.Parse(_currentUserService.Id.ToString()));
            List<MeatEntity> meats = userEntity.Meats;

            for(int i = meats.Count - 1; i >= 0; i--)
            {
                await _meatService.Delete(meats[i].Id);
            }

            return RedirectToAction("Cart", "User");
        }
    }
}