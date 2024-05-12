using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete;

/// <summary>
///     Implementation of user detail repository.
/// </summary>
internal sealed class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
{
    private readonly DatabaseContext _context;

    internal UserDetailRepository(DatabaseContext context)
        : base(context)
    {
        _context = context;
    }
}
