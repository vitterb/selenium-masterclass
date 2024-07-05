using MasterClassProject.Domain.Interfaces;

namespace MasterClassProject.Domain.Entities
{
    public class Company : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; }
    }
}