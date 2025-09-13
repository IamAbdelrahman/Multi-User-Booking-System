using AutoMapper.QueryableExtensions;
using Booking.Application.Common;
using Booking.Application.Common.Interfaces;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;
namespace Booking.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        /*- DEPENDENCIES -*/
        protected readonly BookingDbContext _dbContext;
        protected readonly IMapper _mapper;
        public GenericRepository(BookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper=mapper;
        }
        /*-------------------------------------------------------------------------------*/

        /*- CREATE -*/
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }
        /*-------------------------------------------------------------------------------*/

        /*- READ -*/
        public TEntity? GetById(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity?> GetByIdAsync(
            TKey id,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.SingleOrDefaultAsync(e => e.Id!.Equals(id));
        }
        public async Task<PaginatedResult<TEntity>> GetAllAsync(GetAllQueryDto queryDto,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            return await GetPaginatedResultAsync(queryDto, orderBy, includes);
        }
        /*-------------------------------------------------------------------------------*/

        /*- UPDATE -*/
        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        /*-------------------------------------------------------------------------------*/

        /*- DELETE -*/
        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }
        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
        /*-------------------------------------------------------------------------------*/

        /*- FILTER & SORT -*/
        /// <summary>
        /// Find a single entity based on a predicate with optional includes
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public async Task<TEntity?> Find(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Find all entities based on a filter with pagination and sorting
        /// </summary>
        /// <param name="queryDto"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public async Task<PaginatedResult<TEntity>> FindAll(GetAllQueryDto queryDto,
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            var query = _dbContext.Set<TEntity>().Where(filter);
            return await GetPaginatedResultAsync(queryDto, orderBy, null);

        }

        /// <summary>
        /// Query method to get sorted and filtered list of TDto
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public async Task<List<TDto>> GetSortedFiltered<TDto>(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);


            if (orderBy != null)
                query = orderBy(query);
            else
                query = query.OrderBy(e => e.Id);

            return await query.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        /*-------------------------------------------------------------------------------*/

        /*- PAGINATION -*/
        /// <summary>
        ///     Helper method to get paginated result   
        /// </summary>
        /// <param name="queryDto"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        private async Task<PaginatedResult<TEntity>> GetPaginatedResultAsync(
        GetAllQueryDto queryDto,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[]? includes
    )
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            // Calc pagination meta data
            var metaData = new PaginationMetaData
            {
                Page = queryDto.Page,
                PageSize = queryDto.PageSize,
                Total = await query.CountAsync()
            };

            // Apply includes
            if (includes is not null && includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            if (orderBy is not null)
                query = orderBy(query);

            // Evaluate Query
            var items = await query.AsNoTracking()
                    .Skip(queryDto.CalcSkippedItems())
                    .Take(queryDto.PageSize)
                    .ToListAsync();

            return new PaginatedResult<TEntity>
            {
                Items = items,
                MetaData = metaData
            };
        }

    }
}
