using Microsoft.EntityFrameworkCore;
using Solution.Core.Conext;
using Solution.Core.Interfaces.IRepositories;
using Solution.Core.Models.Entities;

namespace Solution.Repository
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context)
        {
        }

        public override  async Task<List<Player>> GetAllAsync()
        {
            return await _context.Set<Player>()
                                                     .Include(x => x.Position)
                                                     .AsNoTracking()
                                                     .ToListAsync();
        }
    }
}
