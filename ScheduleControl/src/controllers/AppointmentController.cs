using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using ScheduleControl.src.repositories;
using System;
using System.Threading.Tasks;

namespace ScheduleControl.src.controllers
{
    [ApiController]
    [Route("api/Appointment")]
    [Produces("application/json")]
    public class AppointmentController : ControllerBase
    {
        #region Attributes
        private readonly IAppointment _repository;
        #endregion

        public AppointmentController(IAppointment query)
        {
            _repository = query;
        }
        /// <summary>
        /// Create New Appointment
        /// </summary>
        /// <param name="appointment">NewAppointmentDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Requisition example:
        ///
        ///     POST /api/Appointment/Register
        ///     {
        ///        "reason": "Dor nas costas",
        ///        "data": "2022-08-20T19:45:35",
        ///        "doctor": {
        ///             "name": "Cleiton Benicio",
        ///             "occupationArea": "Pediatria",
        ///             "consultationTime": 1
        ///        },
        ///        "patient":{
        ///        "name": "Marcelo"
        ///        "email": "marcelo@email.com"
        ///        }
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Return created appointment</response>
        /// <response code="400"> request error </response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AppointmentModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Register")]
        public async Task<ActionResult> NewAppointmentAsync([FromBody] NewAppointmentDTO appointment)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _repository.NewAppointmentAsync(appointment);
                return Created($"api/Query", appointment);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        /// <summary>
        /// Delete appointment by id
        /// </summary>
        /// <param name="idAppointment">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Query deleted</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idAppointment}")]
        public async Task<ActionResult> DeleteAppointmentAsync([FromRoute] int idAppointment)
        {
            await _repository.DeleteAppointmentAsync(idAppointment);
            return NoContent();
        }
        /// <summary>
        /// Get Appointment by id
        /// </summary>
        /// <param name="idAppointment">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return Appointment</response>
        /// <response code="404">Appointment does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idAppointment}")]
        public async Task<ActionResult> GetAppointmentByIdAsync([FromRoute] int idAppointment)
        {
            var appointment = await _repository.GetAppointmentByIdAsync(idAppointment);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }
        /// <summary>
        /// Get all appointments
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Appointment list</response>
        /// <response code="204">Empty list</response>
        [HttpGet]
        public async Task<ActionResult> GetAllAppointmentAsync()
        {
            var list = await _repository.GetAllAppointmentsAsync();

            if (list.Count < 1) return NoContent();
            return Ok(list);
        }
        /// <summary>
        /// Update Appointment
        /// </summary>
        /// <param name="appointment">UpdateAppointmentDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Requisition example:
        ///
        ///     PUT /api/Appointment
        ///     {
        ///        "id": 1,    
        ///        "data": "2022-08-21T18:54:34.491Z",
        ///        "doctor": {
        ///          "name": "string",
        ///          "occupationArea": "string",
        ///          "consultationTime": 0
        ///          }
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Return updated appointment</response>
        /// <response code="400">Request error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> UpdateAppointmentAsync([FromBody] UpdateAppointmentDTO appointment)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateAppointmentAsync(appointment);

            return Ok(appointment);
        }
    }
}
