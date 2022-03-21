using Microsoft.AspNetCore.Mvc;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models;
using Solution.Core.Models.Requests;
using Solution.Core.Models.Response;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Solution.WebAPI.Controller
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/api/security/login")]
        [SwaggerOperation(OperationId = "login")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TokenResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<TokenResponse> LoginAsync([FromBody] [Required] LoginRequest requestParam)
        {
            ServiceResponse<TokenResponse> request = await _authenticationService.LoginAsync(requestParam);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return request.Object;
        }

        [HttpPost]
        [Route("/api/security/register")]
        [SwaggerOperation(OperationId = "register")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<bool> RegisterAsync([FromBody][Required] RegisterRequest requestParam)
        {
            ServiceResponse request = await _authenticationService.RegisterAync(requestParam);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return true;
        }

        [HttpPost]
        [Route("/api/security/register-admin")]
        [SwaggerOperation(OperationId = "registerAdmin")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<bool> RegisterAdminAsync([FromBody][Required] RegisterRequest requestParam)
        {
            ServiceResponse request = await _authenticationService.RegisterAdminAync(requestParam);

            if (request.HasError)
            {
                throw new Exception(request.ErrorMessage);
            }

            return true;
        }
    }
}
