using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Solution.Core.Conext;
using Solution.Core.Interfaces.IRepositories;
using Solution.Core.Interfaces.IServices;
using Solution.Core.Models.AppSettings;
using Solution.Repository;
using Solution.Services;

namespace Solution.Middleware
{
    public static class DipendencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //adding DbContext
            services.AddDbContext<AppDbContext>(options =>  options.UseSqlServer("Server=.\\SQLEXPRESS;Database=AoVDb;Trusted_Connection=True"));

            //adding Services with Repositories for every layer
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IPositionRepository, PositionRepository>();

            //adding authentication service
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            //adding appSettings.json configurations
            services.Configure<JwtSettings>(configuration.GetSection("JWT"));

            // Add useful interface for accessing the ActionContext outside a controller.
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Add useful interface for accessing the HttpContext outside a controller.
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add useful interface for accessing the IUrlHelper outside a controller.
            services.AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>()
                            .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

        }
    }
}
