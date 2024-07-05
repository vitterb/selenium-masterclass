using MasterClassProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterClassProject.Infrastructure.Extensions
{
    public static class DALRegistrator
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services)
        {
            services.AddDbContext<MasterClass_DbContext>(opt => opt.UseSqlServer("name=ConnectionStrings:MasterClassDataBase"));
            return services;
        }
    }
}