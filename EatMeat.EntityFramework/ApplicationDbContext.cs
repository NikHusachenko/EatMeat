using EatMeat.Database.Entities;
using EatMeat.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EatMeat.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MeatEntity> Meats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MeatConfiguration());
        }
    }
}