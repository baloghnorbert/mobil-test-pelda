using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Solution.Core.Conext;
using Solution.Core.Models.AppSettings;
using System.Text;

namespace Solution.Middleware.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            JwtSettings settings = new JwtSettings();
            configuration.GetSection("JWT")
                                      .Bind(settings);

            string validAudience = settings.ValidAudience;
            string validIssuer = settings.ValidIssuer;
            string secret = settings.Secret;
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            // For Identity
            serviceCollection.AddIdentity<IdentityUser, IdentityRole>()
                                             .AddEntityFrameworkStores<AppDbContext>()
                                             .AddDefaultTokenProviders();

            // Adding Authentication
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = validAudience,
                     ValidIssuer = validIssuer,
                     IssuerSigningKey = key
                 };
             });
        }

        public static void ConfigureAuthentication(this IApplicationBuilder applicationBuilder)
        {
            // Authentication & Authorization
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();
        }
    }
}
