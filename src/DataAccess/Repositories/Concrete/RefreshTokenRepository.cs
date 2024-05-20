using System;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete;

/// <summary>
///     Implementation of refreshToken repository.
/// </summary>
internal sealed class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<RefreshToken> _refreshTokens;

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

    public async Task<bool> CreateRefreshTokenAsync(
        RefreshToken refreshToken,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await _context
                .Set<RefreshToken>()
                .AddAsync(entity: refreshToken, cancellationToken: cancellationToken);

            await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
