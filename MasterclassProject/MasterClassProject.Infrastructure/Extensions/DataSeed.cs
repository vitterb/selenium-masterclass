using MasterClassProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterClassProject.Infrastructure.Extensions
{
    public static class DataSeed
    {
        public static void AppDataSeed(this ModelBuilder modelbuiler)
        {
            var _companies = new List<Company>()
            {
                new Company {Id = 1, Name = "Disney"},
                new Company {Id = 2, Name = "Looney Toons"}
            };

            var _users = new List<User>()
            {
                new User {Id = 1, CompanyId = 1, Name = "Mickey Mouse"},
                new User {Id = 2, CompanyId = 1, Name = "Minnie Mouse"},
                new User {Id = 3, CompanyId = 1, Name = "Donald Duck"},
                new User {Id = 4, CompanyId = 1, Name = "Daisy Duck"},
                new User {Id = 5, CompanyId = 1, Name = "Goofy"},
                new User {Id = 6, CompanyId = 2, Name = "Bugs Bunny"},
                new User {Id = 7, CompanyId = 2, Name = "Daffy Duck"},
                new User {Id = 8, CompanyId = 2, Name = "Wile E. Coyote"},
                new User {Id = 9, CompanyId = 2, Name = "Tweety Bird"},
                new User {Id = 10, CompanyId = 2, Name = "Sylvester The Cat"}
            };

            modelbuiler.Entity<Company>().HasData(_companies);
            modelbuiler.Entity<User>().HasData(_users);
        }
    }
}