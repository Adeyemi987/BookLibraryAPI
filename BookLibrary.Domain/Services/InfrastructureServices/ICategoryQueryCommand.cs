using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BookLibrary.Domain.Services.InfrastructureServices
{
    public interface ICategoryQueryCommand<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync(RequestParams requestParams);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<IPagedList<T>> GetPagedList(RequestParams requestParams, List<string> include = null);

        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
       
    }
}
