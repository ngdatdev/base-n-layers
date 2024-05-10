using DataAccess.Entities;
using DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.EntityConfigurations;

/// <summary>
///     Represent "Users Token" table configuration.
/// </summary>
internal sealed class UserTokenEntityConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        const string TableName = "UserTokens";
        const string TableComment = "Contain user record.";

        builder.ToTable(name: TableName, buildAction: table => table.HasComment(TableComment));

        // ExpiredAt property configuration.
        builder
            .Property(propertyExpression: userToken => userToken.ExpiredAt)
            .HasColumnType(typeName: CommonConstant.SqlDatabase.DataType.DATETIME)
            .IsRequired();
    }
}
