using MasterClassProject.Domain.Entities;
using MasterClassProject.Infrastructure.Context;
using MasterClassProject.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterClass.NetAPITests
{
    public class InfrastructureTests : IDisposable
    {
        private readonly ServiceProvider serviceProvider;
        private readonly MasterClass_DbContext dbContext;

        public InfrastructureTests()
        {
            // Set up an in-memory database for testing
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MasterClass_DbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });
            serviceProvider = serviceCollection.BuildServiceProvider();
            dbContext = serviceProvider.GetRequiredService<MasterClass_DbContext>();
        }

        [Fact]
        public async Task CompanyService_GetAll_ReturnsListOfCompanies()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company { Id = 1, Name = "Company1" },
                new Company { Id = 2, Name = "Company2" },
            };

            dbContext.Company.AddRange(companies);
            dbContext.SaveChanges();

            var companyService = new CompanyService(dbContext);

            // Act
            var result = await companyService.GetAll();

            // Assert
            Assert.Equal(companies, result);
        }

        [Fact]
        public async Task CompanyService_GetById_ReturnsCompany()
        {
            // Arrange
            var company = new Company { Id = 1, Name = "Company1" };

            dbContext.Company.Add(company); // Use "Company" here
            dbContext.SaveChanges();

            var companyService = new CompanyService(dbContext);

            // Act
            var result = await companyService.GetById(1);

            // Assert
            Assert.Equal(company, result);
        }

        [Fact]
        public async Task CompanyService_Add_ReturnsAddedCompany()
        {
            // Arrange
            var newCompany = new Company { Id = 3, Name = "NewCompany" };

            var companyService = new CompanyService(dbContext);

            // Act
            var result = await companyService.Add(newCompany);

            // Assert
            Assert.Equal(newCompany, result);
        }

        [Fact]
        public async Task CompanyService_Update_ReturnsUpdatedCompany()
        {
            // Arrange
            var companyId = 1L;
            var company = new Company { Id = companyId, Name = "Company1" };

            dbContext.Company.Add(company);
            dbContext.SaveChanges();

            var updatedCompany = new Company { Id = companyId, Name = "UpdatedCompany" };

            var companyService = new CompanyService(dbContext);

            // Act

            dbContext.Entry(company).State = EntityState.Detached;
            var result = await companyService.Update(updatedCompany);

            // Assert
            Assert.Equal(updatedCompany, result);
            var dbCompany = await dbContext.Company.FindAsync(companyId);
            Assert.Equal(updatedCompany.Name, dbCompany.Name);
        }

        [Fact]
        public async Task CompanyService_Delete_RemovesCompany()
        {
            // Arrange
            var companyId = 1L;
            var company = new Company { Id = companyId, Name = "Company1" };

            dbContext.Company.Add(company);
            dbContext.SaveChanges();

            var companyService = new CompanyService(dbContext);

            // Act
            await companyService.Delete(companyId);

            // Assert
            var deletedCompany = await dbContext.Company.FindAsync(companyId);
            Assert.Null(deletedCompany);
        }

        public void Dispose()
        {
            // Dispose of the in-memory database after the test
            dbContext.Database.EnsureDeleted();
            serviceProvider.Dispose();
        }
    }
}