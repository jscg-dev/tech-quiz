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
    public class CoursesController : ControllerBase
    {
        private readonly CoursesService _courses;

        public CoursesController(CoursesService courses)
        {
            _courses = courses;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Page([FromQuery] int regs = 10, [FromQuery] int page = 1, [FromQuery] int? group_id = null, [FromQuery] string? name = null)
        {
            try
            {
                ResponsePage<Course> result = await _courses
                    .Page(regs, page, db => db.GroupId == (group_id ?? db.GroupId) && db.Name.Contains(name ?? db.Name));

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
                Course? record = await _courses.Get(id);
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
        public async Task<IActionResult> Add([FromBody] Course record)
        {
            try
            {
                Course added_record = await _courses.Add(record);
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
        public async Task<IActionResult> Update([FromBody] Course record)
        {
            try
            {
                Course updated_record = await _courses.Update(record);
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
                await _courses.Remove(id);
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
