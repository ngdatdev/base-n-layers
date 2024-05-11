using DataAccess.Data.DataContext;
using DataAccess.Repositories.Concrete;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.UnitOfWork;

/// <summary>
///     Implementation of unit of work interface.
/// </summary>
public sealed class SqlUnitOfWork : IUnitOfWork
{
    private IUserDetailRepository _getUserDetailRepository;
    private readonly DatabaseContext _context;

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
}
