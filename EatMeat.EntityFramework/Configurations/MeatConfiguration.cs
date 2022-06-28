using EatMeat.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatMeat.EntityFramework.Configurations
{
    public class MeatConfiguration : IEntityTypeConfiguration<MeatEntity>
    {
        public void Configure(EntityTypeBuilder<MeatEntity> builder)
        {
            builder.ToTable("Meats").HasKey(meat => meat.Id);
            builder.Property(meat => meat.Created).IsRequired(true);
            builder.Property(meat => meat.Name).HasMaxLength(31).IsRequired(true);
            builder.Property(meat => meat.Description).HasMaxLength(255);

            builder.HasOne<UserEntity>(meat => meat.User)
                .WithMany(user => user.Meats)
                .HasForeignKey(meat => meat.UserFK);
        }
    }
}