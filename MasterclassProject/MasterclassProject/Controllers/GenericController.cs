using MasterClassProject.Domain.Interfaces;
using MasterClassProject.Infrastructure.Exceptions;
using MasterCLassProject.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MasterClassProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class, IEntity
    {
        private readonly IGenericService<T> _genericService;

        public GenericController(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _genericService.GetAll();
                if (result == null)
                {
                    Log.Warning("No data found when GetAll() was called");
                    return NotFound("Didn't find any data");
                }
                else
                {
                    Log.Information("GetAll() was called succesfully!");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error: {@ex}", ex);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var entity = await _genericService.GetById(id);

            if (entity != null)
            {
                Log.Information($"GetById() controller called item with id: {id}");
                return Ok(entity);
            }
            else
            {
                Log.Warning($"Item with id:{id} was called and not found.");
                return NotFound($"The item with id: {id} is not found.");
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Add([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning("Posting new object failed.");
                return BadRequest("Sorry your input is invalid.");
            }
            try
            {
                await _genericService.Add(entity);
                Log.Information("Object was succesfully entered in database {@entity}", entity);
                return Ok(entity);
            }
            catch (ServiceException ex)
            {
                Log.Error(ex, "Error occurred while adding the object to the database.");
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (StopBeforeStartException ex)
            {
                Log.Error(ex, "End time must be behind start time!");
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while adding the object to the database.");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning("Updating object failed.");
                return BadRequest("Sorry your input is invalid.");
            }
            var updatedEntity = await _genericService.Update(entity);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _genericService.Delete(id);
                Log.Information($"Deleted item with {id}");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                Log.Warning($"The item with id:{id} doesn't exist");
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                Log.Warning($"Failed to delete item with {id}");
                return Conflict("Item still has dependencies!");
            }
        }
    }
}