using Solution.Core.Interfaces.IEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solution.Core.Interfaces.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> PageAsync(int page = 0);
        Task DeleteAsync(int id);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> CreateAsync(TEntity requestParam);
        Task<TEntity> UpdateAsync(IEntity entity);
    }
}
