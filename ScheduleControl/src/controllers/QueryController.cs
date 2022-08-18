using Microsoft.AspNetCore.Mvc;
using ScheduleControl.src.dtos;
using ScheduleControl.src.repositories;
using System;
using System.Threading.Tasks;

namespace ScheduleControl.src.controllers
{
    [ApiController]
    [Route("api/Query")]
    [Produces("application/json")]
    public class QueryController : ControllerBase
    {
        #region Attributes
        private readonly IQuery _repository;
        #endregion

        public QueryController(IQuery query)
        {
            _repository = query;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> NewQueryAsync([FromBody] NewQueryDTO query)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _repository.NewQueryAsync(query);
                return Created($"api/Query", query);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpDelete("delete/{idQuery}")]
        public async Task<ActionResult> DeleteQueryAsync([FromRoute] int idQuery)
        {
            await _repository.DeleteQueryAsync(idQuery);
            return NoContent();
        }
        [HttpGet("id/{idQuery}")]
        public async Task<ActionResult> GetQueryByIdAsync([FromRoute] int idQuery)
        {
            var query = await _repository.GetQueryById(idQuery);
            if (query == null) return NotFound();
            return Ok(query);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllQueryAsync()
        {
            var list = await _repository.GetAllQueriesAsync();

            if (list.Count < 1) return NotFound();
            return Ok(list);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateQueryAsync([FromBody] UpdateQueryDTO query)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateQueryAsync(query);

            return Ok(query);
        }
    }
}
