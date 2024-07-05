using MasterClassProject.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;

namespace MasterClassProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MasterCLass", Version = "v1" });
            });

            services.RegisterServices();
            services.RegisterContext();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactFrontend", builder =>
                {
                    builder.WithOrigins("https://localhost:44467")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    builder.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    builder.WithOrigins("http://localhost/realms/test")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MasterCLass v1"));
            }

            app.UseCors("AllowReactFrontend");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSerilogRequestLogging();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}