using MasterClassProject.Domain.Interfaces;

namespace MasterClassProject.Domain.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public List<TimeRegistration>? TimeRegistrations { get; set; }
        public Company? Company { get; set; }
    }
}