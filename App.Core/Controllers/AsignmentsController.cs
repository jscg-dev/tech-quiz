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
    public class AsignmentsController : ControllerBase
    {
        private readonly AsignmentsService _asignment;

        public AsignmentsController(AsignmentsService asignment)
        {
            _asignment = asignment;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Page([FromQuery] int regs = 10, [FromQuery] int page = 1, [FromQuery] int? course_id = null, [FromQuery] int? student_id = null)
        {
            try
            {
                ResponsePage<Asignment> result = await _asignment
                    .Page(regs, page, db => course_id != null ? db.CourseId == course_id : true && student_id != null ? db.StudentId == student_id : true);

                return Ok(result);
            }
            catch(RequestViolationException ex)
            {
                return new ObjectResult(ex.Message)
                {
                    StatusCode = ex.Code
                };
            }
            catch(Exception ex)
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
                Asignment? record = await _asignment.Get(id);
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
        public async Task<IActionResult> Add([FromBody] Asignment record)
        {
            try
            {
                Asignment added_record = await _asignment.Add(record);
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
        public async Task<IActionResult> Update([FromBody] Asignment record)
        {
            try
            {
                Asignment updated_record = await _asignment.Update(record);
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
                await _asignment.Remove(id);
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
