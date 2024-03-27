using App.Application.Services;
using App.Domain.Entities;
using App.Domain.Entities.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly MarksService _marks;

        public MarksController(MarksService marks)
        {
            _marks = marks;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Page([FromQuery] int regs = 10, [FromQuery] int page = 1, [FromQuery] int? course_id = null, [FromQuery] int? student_id = null)
        {
            try
            {
                ResponsePage<Mark> result = await _marks
                    .Page(regs, page, db => db.Asignment.CourseId == (student_id ?? db.Asignment.CourseId) && db.Asignment.StudentId == (student_id ?? db.Asignment.StudentId));

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
                Mark? record = await _marks.Get(id);
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
        public async Task<IActionResult> Add([FromBody] Mark record)
        {
            try
            {
                Mark? added_record = await _marks.Add(record);
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
        public async Task<IActionResult> Update([FromBody] Mark record)
        {
            try
            {
                Mark? updated_record = await _marks.Update(record);
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
                await _marks.Remove(id);
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
