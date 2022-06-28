using EatMeat.Database.Enums;

namespace EatMeat.Database.Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserTypes Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public List<MeatEntity> Meats { get; set; }

        public UserEntity()
        {
            Meats = new List<MeatEntity>();
        }
    }
}