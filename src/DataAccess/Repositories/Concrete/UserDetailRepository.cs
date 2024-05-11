using DataAccess.Data.DataContext;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Concrete;

/// <summary>
///     Implementation of user detail repository.
/// </summary>
internal sealed class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
{
    internal UserDetailRepository(DatabaseContext context)
        : base(context) { }
}
