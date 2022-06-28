using EatMeat.Database.Entities;

namespace EatMeat.Web.Views.Shared.Components.MeatItemComponent
{
    public class MeatItemViewModel
    {
        public MeatEntity Meat { get; set; }
        public long? BuyerId { get; set; }
    }
}
