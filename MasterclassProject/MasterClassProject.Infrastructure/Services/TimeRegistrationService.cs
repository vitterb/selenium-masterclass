using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;
using MasterClassProject.Infrastructure.Context;

namespace MasterClassProject.Infrastructure.Services
{
    public class TimeRegistrationService : GenericService<TimeRegistration>, ITimeRegistrationService
    {
        public TimeRegistrationService(MasterClass_DbContext dbContext) : base(dbContext)
        {
        }

        //public List<TimeRegistration> GetTimeRegistrationByUserId(long userId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}