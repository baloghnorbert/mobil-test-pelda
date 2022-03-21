using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Solution.Middleware;
using Solution.Middleware.Configurations;

namespace Solution.WebAPI
{
    public class Startup
    {
        public IWebHostEnvironment _hostingEnvironment { get; private set; }
        public IConfiguration _configuration { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
            _configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(_hostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            _configuration = builder.Build();
        }
            // This method gets called by the runtime. Use this method to add services to the container.
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjection(_configuration);
            services.ConfigureAuthentication(_configuration);
            services.AddMvc();
            services.ConfigureCORS();
            services.ConfigureSwagger();
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.ConfigureAuthentication();

            app.ConfigureCORS();
            app.ConfigureSwagger();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
