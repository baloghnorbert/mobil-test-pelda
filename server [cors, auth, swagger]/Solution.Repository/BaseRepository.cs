using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Solution.Core.Conext;
using Solution.Core.Interfaces.IEntities;
using Solution.Core.Interfaces.IRepositories;

namespace Solution.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity requestParam)
        {
            EntityEntry<TEntity> result = await _context.Set<TEntity>()
                                                                                                      .AddAsync(requestParam);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity entity = await _context.Set<TEntity>()
                                                                        .FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"Hibás {id}.");
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception($"Hibás objektum.");
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                                                     .ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            TEntity entity = await _context.Set<TEntity>()
                                                                       .FindAsync(id);

            return entity;
        }

        public virtual async Task<List<TEntity>> PageAsync(int page = 0)
        {
            return await _context.Set<TEntity>().Skip(page * 10)
                                                                                     .Take(10)
                                                                                     .ToListAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(IEntity entity)
        {
            TEntity toRemove = await GetAsync(entity.Id);

            if (toRemove != null && entity != null)
            {
                _context.Entry(toRemove).State = EntityState.Detached;
                _context.Entry((TEntity)entity).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return (TEntity)entity;
            }

            throw new Exception("Sikertelen muvelet!");
        }
    }
}
