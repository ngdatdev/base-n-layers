using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

/// <summary>
///     Represent methods that encapsulate queries
///     to interact with "UserDetails" table.
/// </summary>
/// <remarks>
///     All repository interfaces must implement
///     <seealso cref="IBaseRepository{TEntity}"/> interface.
/// </remarks>
public interface IUserDetailRepository : IBaseRepository<UserDetail>
{
    Task<bool> IsUserTemporarilyRemovedAsync(Guid id, CancellationToken cancellationToken);
    Task<UserDetail> GetUserDetailByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}
