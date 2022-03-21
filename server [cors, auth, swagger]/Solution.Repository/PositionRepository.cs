using Solution.Core.Conext;
using Solution.Core.Interfaces.IRepositories;
using Solution.Core.Models.Entities;

namespace Solution.Repository
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
