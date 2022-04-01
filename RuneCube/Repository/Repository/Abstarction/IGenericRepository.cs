using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DomainModels.Models.Entities.Base;

namespace Repository.Services.Abstarction
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IList<T> entities);
        Task<bool> DeleteAsync(string id);
        Task<T> GetSkippedAsync(int skipCount, int takeCount);
        bool Update(T entity);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression=null);
        Task<int> GetCountAsync();
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> predicate,IList<string>includingItems=null);
    }
}