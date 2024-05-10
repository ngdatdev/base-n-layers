using DataAccess.Entities;
using DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.EntityConfigurations;

/// <summary>
///     Represent "Users Detail" table configuration.
/// </summary>
internal sealed class UserDetailEntityConfiguration : IEntityTypeConfiguration<UserDetail>
{
    public void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        const string TableName = "UserDetails";
        const string TableComment = "Contain user record.";

        builder.ToTable(
            name: TableName,
            buildAction: table => table.HasComment(comment: TableComment)
        );

        // Primary key configuration.
        builder.HasKey(keyExpression: userDetail => userDetail.UserId);

        // LastName property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.LastName)
            .HasColumnType(
                typeName: CommonConstant.SqlDatabase.DataType.NvarcharGenerator.Get(
                    length: UserDetail.MetaData.LastName.MaxLength
                )
            )
            .IsRequired();

        // FirstName property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.FirstName)
            .HasColumnType(
                typeName: CommonConstant.SqlDatabase.DataType.NvarcharGenerator.Get(
                    length: UserDetail.MetaData.LastName.MaxLength
                )
            )
            .IsRequired();

        // CreatedAt property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.CreatedAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();

        // CreatedBy property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.CreatedBy).IsRequired();

        // UpdatedAt property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.UpdatedAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();

        // UpdatedBy property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.UpdatedBy).IsRequired();

        // RemovedAt property configuration.
        builder
            .Property(propertyExpression: userDetail => userDetail.RemovedAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();

        // RemovedBy property configuration.
        builder.Property(propertyExpression: userDetail => userDetail.RemovedBy).IsRequired();

        // Relationship configurations.
        builder
            .HasMany(navigationExpression: userDetail => userDetail.RefreshTokens)
            .WithOne(navigationExpression: refreshToken => refreshToken.UserDetail)
            .HasForeignKey(foreignKeyExpression: refreshToken => refreshToken.UserId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
    }
}
