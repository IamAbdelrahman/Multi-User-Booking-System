using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Common.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public TEntity? GetById(TKey id);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        
        Task<PaginatedResult<TEntity>> GetAllAsync(GetAllQueryDto queryDto,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            params Expression<Func<TEntity, object>>[]? includes);
        Task<PaginatedResult<TEntity>> FindAll(GetAllQueryDto queryDto,
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy);

        Task<List<TDto>> GetSortedFiltered<TDto>(
             Expression<Func<TEntity, bool>>? filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
             params Expression<Func<TEntity, object>>[]?includes);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TKey id);
    }


}
