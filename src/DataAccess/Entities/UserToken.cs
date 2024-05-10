using System;
using DataAccess.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities;

/// <summary>
///     Represent the "UserTokens" table.
/// </summary>
public class UserToken : IdentityUserToken<Guid>, IBaseEntity
{
    public DateTime ExpiredAt { get; set; }

    // Navigation properties.
    public User User { get; set; }
}
