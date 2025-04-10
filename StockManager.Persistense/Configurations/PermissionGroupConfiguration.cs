using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManager.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace StockManager.Persistense.Configurations
{
    public class PermissionGroupConfiguration : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> builder) {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            //EF Relations
            builder.HasMany(x => x.Permissions).WithOne().HasForeignKey(x => x.PermissionGroupId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
