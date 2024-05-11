using DataAccess.Repositories.Interfaces;

namespace DataAccess.UnitOfWork;

/// <summary>
///     Represent the base unit of work.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     UserDetail comment repository.
    /// </summary>
    IUserDetailRepository UserDetailRepository { get; }
}
