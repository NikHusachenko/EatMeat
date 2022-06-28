using EatMeat.Database.Entities;
using EatMeat.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EatMeat.Web.Views.Shared.Components.NavbarComponent
{
    public class NavbarComponent : ViewComponent
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;

        public NavbarComponent(ICurrentUserService currentUserService,
            IUserService userService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            NavbarViewModel vm = new NavbarViewModel()
            {
                IsAdmin = _currentUserService.IsAdmin,
                IsAuthorize = _currentUserService.IsAuthenticated,
            };

            string userIdString = _currentUserService.Id.ToString();
            
            if(userIdString != String.Empty)
            {
                UserEntity user = await _userService.GetByIdAsync(long.Parse(userIdString));
                vm.CartLength = user.Meats.Count;
            }
            
            return View(vm);
        }
    }
}
