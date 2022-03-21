using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models;
using Solution.Core.Models.AppSettings;
using Solution.Core.Models.Common;
using Solution.Core.Models.Requests;
using Solution.Core.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Solution.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _settings;

        public AuthenticationService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtSettings> settings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _settings = settings.Value;
        }

        public async Task<ServiceResponse<TokenResponse>> LoginAsync(LoginRequest request)
        {
            ServiceResponse<TokenResponse> response = null;

            try
            {
                IdentityUser user = await _userManager.FindByNameAsync(request.Username);
                bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
                if (user == null || !isPasswordValid)
                {
                    throw new UnauthorizedAccessException("Unauthorized");
                }

                IList<string> userRoles = await _userManager.GetRolesAsync(user);

                List<Claim> authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (string userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                JwtSecurityToken token = GetToken(authClaims);

                response = new ServiceResponse<TokenResponse>(new TokenResponse(token));
            }
            catch (Exception ex)
            {
                response = new ServiceResponse<TokenResponse>(true, ex.Message, null);
            }

            return response;
        }

        public async Task<ServiceResponse> RegisterAync(RegisterRequest request)
        {
            ServiceResponse response = null;

            try
            {
                IdentityUser? userExists = await _userManager.FindByNameAsync(request.Username);
                if (userExists != null)
                {
                    throw new Exception("User already exists!");
                }

                IdentityUser user = new()
                {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Username
                };
                IdentityResult result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("User creation failed! Please check user details and try again.");
                }

                response = new ServiceResponse();
            }
            catch (Exception ex)
            {
                response = new ServiceResponse(true, ex.Message);
            }

            return response;
        }

        public async Task<ServiceResponse> RegisterAdminAync(RegisterRequest request)
        {
            ServiceResponse response = null;

            try
            {
                IdentityUser? userExists = await _userManager.FindByNameAsync(request.Username);
                if (userExists != null)
                {
                    throw new Exception("User already exists!");
                }

                IdentityUser user = new()
                {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Username
                };

                IdentityResult? result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("User creation failed! Please check user details and try again.");
                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                }

                if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _userManager.AddToRoleAsync(user, UserRoles.User);
                }

                response = new ServiceResponse();
            }
            catch (Exception ex)
            {
                response = new ServiceResponse(true, ex.Message);
            }

            return response;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));

            JwtSecurityToken? token = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
