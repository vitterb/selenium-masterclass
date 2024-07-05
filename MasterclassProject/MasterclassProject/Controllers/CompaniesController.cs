using MasterClassProject.Controllers;
using MasterClassProject.Domain.Entities;
using MasterClassProject.Domain.Interfaces;

public class CompaniesController : GenericController<Company>
{
    public CompaniesController(ICompanyService service) : base(service)
    {
    }
}