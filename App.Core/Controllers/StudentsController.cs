using App.Application.Services;
using App.Domain.Entities.Application;
using App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _students;

        public StudentsController(StudentsService students)
        {
            _students = students;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Page([FromQuery] int regs = 10, [FromQuery] int page = 1, [FromQuery] string? dni = null, [FromQuery] string? name = null)
        {
            try
            {
                ResponsePage<Students> result = await _students
                    .Page(regs, page, db => db.Dni.Contains(dni ?? db.Dni) && db.Name.Contains(name ?? db.Name));

                return Ok(result);
            }
            catch (RequestViolationException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = ex.Code
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                Students? record = await _students.Get(id);
                return record != null ? Ok(record) : NotFound();
            }
            catch (RequestViolationException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = ex.Code
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Add([FromBody] Students record)
        {
            try
            {
                Students? added_record = await _students.Add(record);
                return Ok(added_record);
            }
            catch (RequestViolationException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = ex.Code
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> Update([FromBody] Students record)
        {
            try
            {
                Students? updated_record = await _students.Update(record);
                return Ok(updated_record);
            }
            catch (RequestViolationException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = ex.Code
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500
                };
            }
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> remove([FromRoute] int id)
        {
            try
            {
                await _students.Remove(id);
                return NoContent();
            }
            catch (RequestViolationException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = ex.Code
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = 500
                };
            }
        }
    }
}
