using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

/// <summary>
///     Represent methods that encapsulate queries
///     to interact with "Users" table.
/// </summary>
/// <remarks>
///     All repository interfaces must implement
///     <seealso cref="IBaseRepository{TEntity}"/> interface.
/// </remarks>
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> FindUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> IsUserFoundByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<User> FindUserByUsernameAsync(string username, CancellationToken cancellationToken);
}
