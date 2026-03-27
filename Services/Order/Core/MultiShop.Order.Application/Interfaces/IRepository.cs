using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
