using Hotel_List_API.Configuration.Models;

namespace Hotel_List_API.Configuration.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameter queryParameters);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<bool> Exists(int id);
        Task<List<TResult>> GetAllAsync<TResult>();
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBaseDTO;
        Task<TResult> GetAsync<TResult>(int? id);
    }
}
