using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.Pagination;
using BookLibrary.Domain.Services.InfrastructureServices;
using BookLibrary.Infrastructure.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BookLibrary.Infrastructure.Services
{
    public class BookLibraryGenericQuery<T> : IBookLibraryGenericQuery<T> where T : class, IEntityBase, new()
    {
        private readonly BookLibraryDbContext _context;

        public BookLibraryGenericQuery(BookLibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync(RequestParams requestParams) => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);

        }

        public async Task<IPagedList<T>> GetPagedList(RequestParams requestParams, List<string> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (include != null)
            {
                foreach (var includeProperty in include)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
    //public class BookLibraryGenericQuery<T> : IBookLibraryGenericQuery<T> where T : class, IEntityBase, new()
    //{
    //    private readonly BookLibraryDbContext _context;

    //    public BookLibraryGenericQuery(BookLibraryDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task AddAsync(T entity)
    //    {
    //        await _context.Set<T>().AddAsync(entity);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeleteAsync(int id)
    //    {
    //        var entity = await _context.Set<T>().FindAsync(id);
    //        EntityEntry entityEntry = _context.Entry<T>(entity);
    //        entityEntry.State = EntityState.Deleted;
    //        await _context.SaveChangesAsync();
    //    }
    //    public async Task<IEnumerable<T>> GetAllAsync(RequestParams requestParams)=> await _context.Set<T>().ToListAsync();

    //    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        IQueryable<T> query = _context.Set<T>();
    //        query = includeProperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
    //        return await query.ToListAsync();

    //    }

    //    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

    //    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        IQueryable<T> query = _context.Set<T>();
    //        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    //        return await query.FirstOrDefaultAsync(n => n.Id == id);
    //    }

    //    public Task<IPagedList<T>> GetPagedList(RequestParams requestParams, List<string> include = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task UpdateAsync(T entity)
    //    {
    //        EntityEntry entityEntry = _context.Entry<T>(entity);
    //        entityEntry.State = EntityState.Modified;
    //        await _context.SaveChangesAsync();

    //    }



















    //}
}

