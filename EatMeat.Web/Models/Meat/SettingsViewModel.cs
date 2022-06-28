using EatMeat.Database.Entities;

namespace EatMeat.Web.Models.Meat
{
    public class SettingsViewModel
    {
        public List<MeatEntity> Meats { get; set; }

        public SettingsViewModel()
        {
            Meats = new List<MeatEntity>();
        }
    }
}
