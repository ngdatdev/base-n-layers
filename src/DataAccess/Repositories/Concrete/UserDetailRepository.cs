using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Common;

namespace DataAccess.Repositories.Concrete;

/// <summary>
///     Implementation of user detail repository.
/// </summary>
internal sealed class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<UserDetail> _userDetails;

    internal UserDetailRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
        _userDetails = _context.Set<UserDetail>();
    }

    public Task<bool> IsUserTemporarilyRemovedAsync(Guid id, CancellationToken cancellationToken)
    {
          return _userDetails.AnyAsync(
            predicate: userDetail =>
                userDetail.UserId == id
                && userDetail.RemovedBy != CommonConstant.App.DEFAULT_ENTITY_ID_AS_GUID
                && userDetail.RemovedAt != DateTime.MinValue,
            cancellationToken: cancellationToken
        );
    }
}
