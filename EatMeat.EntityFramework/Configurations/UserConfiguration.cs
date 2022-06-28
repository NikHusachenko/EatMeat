using EatMeat.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatMeat.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users").HasKey(user => user.Id);

            builder.Property(user => user.Created).IsRequired(true);
            builder.Property(user => user.Login).HasMaxLength(15);
            builder.Property(user => user.Password).HasMaxLength(15);
        }
    }
}