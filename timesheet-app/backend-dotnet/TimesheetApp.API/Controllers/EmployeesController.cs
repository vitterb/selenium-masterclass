using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TimesheetApp.Application.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimesheetApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetEmployeesQuery());
            return Ok(result.ToList());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("AddRegistration")]
        public async Task<IActionResult> AddRegistration(AddRegistrationDTO addRegistrationDTO)
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User ID not found in token" });
            }

            await _mediator.Send(new AddRegistrationCommand(userId, addRegistrationDTO));
            return Ok(new { message = "Timesheet Registration succesful added" });
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}