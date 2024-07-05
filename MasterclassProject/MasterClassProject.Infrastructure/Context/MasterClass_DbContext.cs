using MasterClassProject.Domain.Entities;
using MasterClassProject.Infrastructure.Configuration;
using MasterClassProject.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MasterClassProject.Infrastructure.Context

{
    public class MasterClass_DbContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<TimeRegistration> TimeRegistration { get; set; }
        public DbSet<User> User { get; set; }

        public MasterClass_DbContext(DbContextOptions<MasterClass_DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TimeRegistrationConfiguration());

            modelBuilder.AppDataSeed();
        }
    }
}