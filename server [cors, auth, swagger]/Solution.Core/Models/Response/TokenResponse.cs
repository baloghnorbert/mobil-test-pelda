using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Solution.Core.Models.Response
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "expiration")]
        public DateTime Expiration { get; set; }

        public TokenResponse()
        {
        }

        public TokenResponse(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public TokenResponse(JwtSecurityToken jwtSecurityToken)
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            Expiration = jwtSecurityToken.ValidTo;
        }
    }
}
