using Solution.Core.Interfaces.IRepositories;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models;
using Solution.Core.Models.Entities;

namespace Solution.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<ServiceResponse<List<Position>>> GetAllAsync()
        {
            ServiceResponse<List<Position>> response = null;

            try
            {
                response = new ServiceResponse<List<Position>>();

                response.Object = await _positionRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<List<Position>>(true, ex.Message, null);
            }

            return response;
        }
    }
}
