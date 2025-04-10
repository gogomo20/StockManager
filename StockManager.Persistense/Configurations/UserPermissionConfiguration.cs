using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;

namespace StockManager.Persistense.Configurations;

public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.HasData(
            new UserPermission { Id= 1,UserId = 1, PermissionId = 1 },
            new UserPermission { Id=2,UserId = 1, PermissionId = 2 },
            new UserPermission { Id=3,UserId = 1, PermissionId = 3 },
            new UserPermission { Id=4,UserId = 1, PermissionId = 4 },
            new UserPermission { Id=5,UserId = 1, PermissionId = 5 }
            );
    }
}