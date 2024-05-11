using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities.Base;

namespace DataAccess.Repositories.Interfaces;

/// <summary>
///     Represent the base repository that every
///     repository that is created must inherit from
///     this interface.
/// </summary>
/// <typeparam name="TEntity">
///     Represent the table of the database or
///     in the simple term, entity of the system.
/// </typeparam>
/// <remarks>
///     All repository interfaces must inherit from
///     this base interface.
/// </remarks>
public interface IBaseRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    /// <summary>
    ///     Synchronously get a list of entity which satisfies
    ///     the specifications.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing list of found entities.
    /// </returns>
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Asynchronously find the entity which satisfies
    ///     the specifications.
    /// </summary>
    /// <param name="Id">
    ///     Id have guid type to find
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the found entity.
    /// </returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    ///     Asynchronously change the state of entity to
    ///     <seealso cref="EntityState.Added"/>.
    /// </summary>
    /// <param name="newEntity">
    ///     The entity for adding to the database.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing result of operation.
    /// </returns>
    Task AddAsync(TEntity newEntity, CancellationToken cancellationToken);

    /// <summary>
    ///     Asynchronously update the entity using bulk method.
    /// </summary>
    /// <param name="entity">
    ///     The entity for update to the database.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing result of operation.
    /// </returns>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    ///     Asynchronously delete the entity using bulk method.
    /// </summary>
    /// <param name="entity">
    ///     The entity for delete to the database.

    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing result of operation.
    /// </returns>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}
