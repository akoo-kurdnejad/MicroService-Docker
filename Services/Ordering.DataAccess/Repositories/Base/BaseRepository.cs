using Microsoft.EntityFrameworkCore;
using Ordering.DataAccess.EF.DBContext;
using Ordering.Domain.Common;
using Ordering.Domain.Repositories.Base;
using System.Linq.Expressions;

namespace Ordering.DataAccess.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Constructor
        private DbSet<TEntity> _dbSet;
        public BaseRepository(OrderingDBContext dbContext)
        {
            DBContext = dbContext;
            _dbSet = DBContext.Set<TEntity>();
        }
        protected OrderingDBContext DBContext { get; }
        #endregion Constructor

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();

            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null) return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstAsync(current => current.Id == id, cancellationToken);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.CreateDate = DateTime.Now;
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public void Update(TEntity entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            ////DBContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await DBContext.SaveChangesAsync(cancellationToken);
        }
    }
}
