using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Aplication.Utils;
using StockManager.Domain.Entities;

namespace StockManager.Persistense.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.UserName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
        
        // EF Configuration
        builder.HasMany(x => x.Permissions).WithMany().UsingEntity<UserPermission>(x =>
        {
            x.HasOne(y => y.Permission)
                .WithMany()
                .HasForeignKey(fk => fk.PermissionId)
                .OnDelete(DeleteBehavior.NoAction);
            x.HasOne(y => y.User)
                .WithMany()
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        });
        builder.HasData(
            new User
            {
                Id = 1,
                Name = "admin",
                UserName = "admin",
                Email = "admin@admin",
                Password = StringUtils.GetBcryptHash("a123457z"),
                Permissions = []
            });
    }
}