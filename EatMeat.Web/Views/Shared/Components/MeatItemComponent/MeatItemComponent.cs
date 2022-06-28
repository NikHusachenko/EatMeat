using EatMeat.Database.Entities;
using EatMeat.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EatMeat.Web.Views.Shared.Components.MeatItemComponent
{
    public class MeatItemComponent : ViewComponent
    {
        private readonly ICurrentUserService _currentUserService;

        public MeatItemComponent(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IViewComponentResult> InvokeAsync(MeatEntity meatEntity)
        {
            MeatItemViewModel vm = new MeatItemViewModel()
            {
                Meat = meatEntity,
                BuyerId = _currentUserService.Id,
            };
            return View(vm);
        }
    }
}
