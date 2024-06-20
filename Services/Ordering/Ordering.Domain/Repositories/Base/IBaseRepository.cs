using Ordering.Domain.Common;
using System.Linq.Expressions;

namespace Ordering.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                              string includeString = null,
                                              bool disableTracking = true,
                                              CancellationToken cancellationToken = default);

        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                              List<Expression<Func<TEntity,object>>> includes = null,
                                              bool disableTracking = true,
                                              CancellationToken cancellationToken = default);

        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
