using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Solution.Middleware.Configurations
{
    public static class CorsConfiguration
    {
        public static void ConfigureCORS(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(options =>
            {
#if DEBUG
                options.AddPolicy("Debug", builder =>
                {
                    builder.WithOrigins()
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
#else
            string[] origins = BuildOrigins();

                options.AddPolicy("Production", builder =>
                {
                    builder.WithOrigins(origins)
                                   .SetIsOriginAllowedToAllowWildcardSubdomains()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                });
#endif
            });
        }

        public static void ConfigureCORS(this IApplicationBuilder applicationBuilder)
        {
#if DEBUG
            applicationBuilder.UseCors("Debug");
#else
            applicationBuilder.UseCors("Production");
#endif
        }

        private static string[] BuildOrigins()
        {
            List<string> origins = new List<string>()
            {
                "aov.com",
                 "localhost:8100"
            };

            List<string> result = new List<string>();
            foreach (string origin in origins)
            {
                result.Add($"https://{origin}");
                result.Add($"http://{origin}");
                result.Add($"https://*.{origin}");
                result.Add($"http://*.{origin}");
            };

            return result.ToArray();
        }
    }
}
