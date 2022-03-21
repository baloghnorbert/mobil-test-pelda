using Solution.Core.Models;
using Solution.Core.Models.Requests;
using Solution.Core.Models.Response;
using System.Threading.Tasks;

namespace Solution.Core.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<TokenResponse>> LoginAsync(LoginRequest request);
        Task<ServiceResponse> RegisterAdminAync(RegisterRequest request);
        Task<ServiceResponse> RegisterAync(RegisterRequest request);
    }
}
