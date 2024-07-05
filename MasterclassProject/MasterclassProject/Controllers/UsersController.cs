using MasterClassProject.Controllers;
using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;

public class UsersController : GenericController<User>
{
    public UsersController(IUserService service) : base(service)
    {
    }
}