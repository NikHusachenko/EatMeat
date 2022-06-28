using EatMeat.Database.Enums;

namespace EatMeat.Database.Entities
{
    public class MeatEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public MeatTypes Type { get; set; }
        public MeatSource Source { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public long? UserFK { get; set; }
        public UserEntity User { get; set; }
    }
}