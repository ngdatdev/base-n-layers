using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete
{
    internal sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DatabaseContext _context;
        private DbSet<User> _users;

        public UserRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
            _users = _context.Set<User>();
        }

        public async Task<User> FindUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _users
                .AsNoTracking()
                .Where(predicate: user => user.Id == id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<bool> IsUserFoundByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _users.AnyAsync(
                predicate: user => user.Id == id,
                cancellationToken: cancellationToken
            );
        }
    }
}
