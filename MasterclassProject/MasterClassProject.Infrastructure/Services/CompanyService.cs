using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;
using MasterClassProject.Infrastructure.Context;

namespace MasterClassProject.Infrastructure.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        public CompanyService(MasterClass_DbContext dbContext) : base(dbContext)
        {
        }
    }
}