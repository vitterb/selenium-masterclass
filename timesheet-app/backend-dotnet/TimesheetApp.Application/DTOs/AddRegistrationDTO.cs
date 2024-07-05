namespace TimesheetApp.Application.DTOs
{
    public class AddRegistrationDTO
    {
        public string RegistrationType { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}