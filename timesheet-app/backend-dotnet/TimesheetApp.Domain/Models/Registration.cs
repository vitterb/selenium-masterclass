using TimesheetApp.Domain.Models.ValueObjects;

namespace TimesheetApp.Domain.Models
{
    public class Registration
    {
        public Registration()
        { }

        public Registration(string registrationType, TimeSlot timeSlot)
        {
            RegistrationType = registrationType;
            TimeSlot = timeSlot;
        }

        public int Id { get; private set; }
        public string RegistrationType { get; private set; }
        public TimeSlot TimeSlot { get; private set; }

        public void ChangeTimeSlot(TimeSlot timeSlot)
        {
            TimeSlot = timeSlot;
        }
    }
}