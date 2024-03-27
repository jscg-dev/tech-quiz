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
    public class GroupsController : ControllerBase
    {
        private readonly GroupsService _groups;

        public GroupsController(GroupsService groups)
        {
            _groups = groups;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Page([FromQuery] int regs = 10, [FromQuery] int page = 1)
        {
            try
            {
                ResponsePage<Group> result = await _groups
                    .Page(regs, page, db => true);

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
                Group? record = await _groups.Get(id);
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
        public async Task<IActionResult> Add([FromBody] Group record)
        {
            try
            {
                Group? added_record = await _groups.Add(record);
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
        public async Task<IActionResult> Update([FromBody] Group record)
        {
            try
            {
                Group? updated_record = await _groups.Update(record);
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
                await _groups.Remove(id);
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
