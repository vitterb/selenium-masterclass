using MediatR;
using TimesheetApp.Domain.Interfaces;
using TimesheetApp.Domain.Models;

namespace TimesheetApp.Application.Queries.EmployeeQueries
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAll();
        }
    }
}