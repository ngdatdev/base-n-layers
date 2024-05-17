using DataAccess.Data.DataContext;
using DataAccess.Repositories.Concrete;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.UnitOfWork;

/// <summary>
///     Implementation of unit of work interface.
/// </summary>
public sealed class SqlUnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    private IUserDetailRepository _getUserDetailRepository;
    private IUserRepository _getUserRepository;
    private IRefreshTokenRepository _refreshTokenRepository;

    public SqlUnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    public IUserDetailRepository UserDetailRepository
    {
        get
        {
            _getUserDetailRepository ??= new UserDetailRepository(context: _context);

            return _getUserDetailRepository;
        }
    }

    public IRefreshTokenRepository RefreshTokenRepository
    {
        get
        {
            _refreshTokenRepository ??= new RefreshTokenRepository(context: _context);

            return _refreshTokenRepository;
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            _getUserRepository ??= new UserRepository(context: _context);

            return _getUserRepository;
        }
    }
}
