using MasterClassProject.Domain.Interfaces;
using MasterCLassProject.Domain.Exceptions;
using Serilog;

namespace MasterClassProject.Domain.Entities
{
    public class TimeRegistration : IEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public User? User { get; set; }

        public TimeRegistration(string description, DateTime start, DateTime stop)
        {
            Description = description;
            Start = start;
            Stop = stop;
            IsValid();
        }

        private void IsValid()
        {
            if (Stop < Start)
            {
                Log.Error("Stop time is before Start time");
                throw new StopBeforeStartException("Stop time is before Start time");
            }
        }
    }
}