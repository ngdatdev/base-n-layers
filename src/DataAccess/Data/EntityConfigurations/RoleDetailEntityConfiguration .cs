using DataAccess.Entities;
using DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.EntityConfigurations;

/// <summary>
///     Represents configuration of "Roles Detail" table.
/// </summary>
internal sealed class RoleDetailEntityConfiguration : IEntityTypeConfiguration<RoleDetail>
{
    public void Configure(EntityTypeBuilder<RoleDetail> builder)
    {
        builder.ToTable(
            name: $"{nameof(RoleDetail)}s",
            buildAction: table => table.HasComment(comment: "Contain role detail records.")
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: roleDetail => roleDetail.RoleId);

        // CreatedAt property configuration.
        builder
            .Property(propertyExpression: roleDetail => roleDetail.CreatedAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();

        // CreatedBy property configuration.
        builder.Property(propertyExpression: roleDetail => roleDetail.CreatedBy).IsRequired();

        // UpdatedAt property configuration.
        builder
            .Property(propertyExpression: roleDetail => roleDetail.UpdatedAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();

        // UpdatedBy property configuration.
        builder.Property(propertyExpression: roleDetail => roleDetail.UpdatedBy).IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: roleDetail => roleDetail.RemovedAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();

        // RemovedBy property configuration.
        builder.Property(propertyExpression: roleDetail => roleDetail.RemovedBy).IsRequired();
    }
}
