using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.EntityConfigurations;

/// <summary>
///     Represents configuration of "Roles" table.
/// </summary>
internal sealed class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(
            name: $"{nameof(Role)}s",
            buildAction: table => table.HasComment(comment: "Contain role records.")
        );

        builder
            .HasMany(navigationExpression: role => role.UserRoles)
            .WithOne(navigationExpression: userRole => userRole.Role)
            .HasForeignKey(foreignKeyExpression: userRole => userRole.RoleId)
            .IsRequired();

        
    }
}
