using Solution.Core.Interfaces.IRepositories;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models;
using Solution.Core.Models.Entities;
using Solution.Core.Models.Requests;

namespace Solution.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<ServiceResponse<Player>> CreateAsync(PlayerRequest requestParam)
        {
            ServiceResponse<Player> response = null;

            try
            {
                response = new ServiceResponse<Player>();

                Player player = new Player(requestParam);
                response.Object = await _playerRepository.CreateAsync(player);
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<Player>(true, ex.Message, null);
            }

            return response;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            ServiceResponse response = null;

            try
            {
                response = new ServiceResponse();

               await _playerRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                response = new ServiceResponse(true, ex.Message);
            }

            return response;
        }

        public async Task<ServiceResponse<List<Player>>> GetAllAsync()
        {
            ServiceResponse<List<Player>> response = null;

            try
            {
                response = new ServiceResponse<List<Player>>();

                response.Object = await _playerRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<List<Player>>(true, ex.Message, null);
            }

            return response;
        }

        public async Task<ServiceResponse<Player>> GetAsync(int id)
        {
            ServiceResponse<Player> response = null;

            try
            {
                response = new ServiceResponse<Player>();

                response.Object = await _playerRepository.GetAsync(id);
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<Player>(true, ex.Message, null);
            }

            return response;
        }

        public async Task<ServiceResponse<List<Player>>> PageAsync(int page = 0)
        {
            ServiceResponse<List<Player>> response = null;

            try
            {
                response = new ServiceResponse<List<Player>>();

                response.Object = await _playerRepository.PageAsync(page);
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<List<Player>>(true, ex.Message, null);
            }

            return response;
        }

        public async Task<ServiceResponse<Player>> UpdateAsync(Player requestParam)
        {
            ServiceResponse<Player> response = null;

            try
            {
                response = new ServiceResponse<Player>();

                response.Object = await _playerRepository.UpdateAsync(requestParam);
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<Player>(true, ex.Message, null);
            }

            return response;
        }
    }
}