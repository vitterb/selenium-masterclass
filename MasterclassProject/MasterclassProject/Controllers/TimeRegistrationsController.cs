using MasterClassProject.Controllers;
using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;

public class TimeRegistrationsController : GenericController<TimeRegistration>
{
    public TimeRegistrationsController(ITimeRegistrationService service) : base(service)
    {
    }
}