using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Data.DataContext;
using DataAccess.Entities.Base;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity newEntity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
