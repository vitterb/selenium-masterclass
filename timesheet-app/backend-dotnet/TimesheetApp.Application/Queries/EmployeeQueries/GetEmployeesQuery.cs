using MediatR;
using TimesheetApp.Domain.Models;

public record GetEmployeesQuery() : IRequest<IEnumerable<Employee>>;