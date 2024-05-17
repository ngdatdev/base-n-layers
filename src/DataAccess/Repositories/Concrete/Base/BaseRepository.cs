using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
///     Implementation of base interface repository.
/// </summary>
namespace DataAccess.Repositories.Concrete
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        private protected BaseRepository(DatabaseContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task AddAsync(TEntity newEntity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(newEntity, cancellationToken: cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
