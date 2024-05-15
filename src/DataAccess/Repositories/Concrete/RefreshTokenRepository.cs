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
    internal sealed class RefreshTokenRepository
        : BaseRepository<RefreshToken>,
            IRefreshTokenRepository
    {
        private readonly DatabaseContext _context;
        private DbSet<RefreshToken> _refreshTokens;

        internal RefreshTokenRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
            _refreshTokens = _context.Set<RefreshToken>();
        }

        public async Task<bool> IsRefreshTokenFoundByAccessTokenIdQueryAsync(
            Guid accessTokenId,
            CancellationToken cancellationToken
        )
        {
            return await _refreshTokens.AnyAsync(
                predicate: refreshToken => refreshToken.AccessTokenId == accessTokenId,
                cancellationToken: cancellationToken
            );
        }
    }
}
