using System;
using System.Collections;
using System.Collections.Generic;
using DataAccess.Entities.Base;

namespace DataAccess.Entities;

/// <summary>
///     Represent the "UserDetails" table.
/// </summary>
public class UserDetail : IBaseEntity, ICreatedEntity, IUpdatedEntity, ITemporarilyRemovedEntity
{
    // Primary keys.
    public Guid UserId { get; set; }

    // Normal columns.
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string AvatarUrl { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    // Navigation properties.
    public User User { get; set; }

    // Navigation collections.
    public IEnumerable<RefreshToken> RefreshTokens { get; set; }

    public static class MetaData
    {
        public static class LastName
        {
            public const int MinLength = 2;

            public const int MaxLength = 50;
        }

        public static class FirstName
        {
            public const int MinLength = 2;

            public const int MaxLength = 50;
        }

        public static class AvatarUrl
        {
            public const int MinLength = 2;
        }

        public static class BackgroundUrl
        {
            public const int MinLength = 2;
        }
    }
}
