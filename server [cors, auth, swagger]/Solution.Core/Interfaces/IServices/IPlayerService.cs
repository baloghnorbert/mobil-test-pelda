using Solution.Core.Models;
using Solution.Core.Models.Entities;
using Solution.Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Solution.Core.Interfaces.IServices
{
    public interface IPlayerService
    {
        Task<ServiceResponse<List<Player>>> GetAllAsync();
        Task<ServiceResponse<Player>> GetAsync(int id);
        Task<ServiceResponse<List<Player>>> PageAsync(int page = 0);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<ServiceResponse<Player>> CreateAsync(PlayerRequest requestParam);
        Task<ServiceResponse<Player>> UpdateAsync(Player requestParam);
    }
}
