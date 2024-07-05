using MasterClassProject.Domain.Interfaces;
using MasterClassProject.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MasterClassProject.Infrastructure.Extensions
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ITimeRegistrationService, TimeRegistrationService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}