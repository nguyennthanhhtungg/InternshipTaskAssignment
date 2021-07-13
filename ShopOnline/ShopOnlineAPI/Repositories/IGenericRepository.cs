using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
    }
}
