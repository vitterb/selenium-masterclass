using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;
using MasterClassProject.Infrastructure.Context;

namespace MasterClassProject.Infrastructure.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(MasterClass_DbContext dbContext) : base(dbContext)
        {
        }

        //public List<User> GetUserByCompanyId(long companyId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}