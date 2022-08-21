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
    [Route("api/Doctor")]
    [Produces("application/json")]
    public class DoctorController : ControllerBase
    {
        #region Attributes
        private readonly IDoctor _repository;
        #endregion

        public DoctorController(IDoctor doctor)
        {
            _repository = doctor;
        }

        /// <summary>
        /// Create New Doctor
        /// </summary>
        /// <param name="doctor">NewDoctorDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Requisition example:
        ///
        ///     POST /api/Doctor
        ///     {
        ///        "name": "Cleiton Benicio",
        ///        "occupationArea": "Pediatria",
        ///        "consultationTime": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Return created Doctor</response>
        /// <response code="400"> request error </response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DoctorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> NewDoctorAsync([FromBody] NewDoctorDTO doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _repository.NewDoctorAsync(doctor);
                return Created($"api/Doctor", doctor);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        /// <summary>
        /// Get doctor by id
        /// </summary>
        /// <param name="idDoctor">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return Doctor</response>
        /// <response code="404">Doctor does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idDoctor}")]
        public async Task<ActionResult> GetDoctorById([FromRoute] int idDoctor)
        {
            var doctor= await _repository.GetDoctorByIdAsync(idDoctor);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }
        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Doctor list</response>
        /// <response code="204">Empty list</response>
        [HttpGet]
        public async Task<ActionResult> GetAllDoctorsAsync()
        {
            var list = await _repository.GetAllDoctors();

            if (list.Count < 1) return NotFound();
            return Ok(list);
        }
        /// <summary>
        /// Get doctor by occupationArea
        /// </summary>
        /// <param name="occupationArea">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return the Occupation</response>
        /// <response code="204">The Occupation does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DoctorModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("occupationArea")]
        public async Task<ActionResult> GetDoctorByOccupationAreaAsync([FromQuery] string occupationArea)
        {
            var occupation = await _repository.GetDoctorByOccupationAreaAsync(occupationArea);

            if (occupation.Count < 1) return NoContent();
            return Ok(occupation);
        }
        /// <summary>
        /// Update Doctor
        /// </summary>
        /// <param name="doctor">UpdateUserDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Requisition example:
        ///
        ///     PUT /api/Doctor
        ///     {
        ///        "id": 1,    
        ///        "occupationArea": "Cirurgião"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Return updated doctor</response>
        /// <response code="400">Request error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> UpdateDoctorAsync([FromBody] UpdateDoctorDTO doctor)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateDoctorAsync(doctor);

            return Ok(doctor);
        }
        /// <summary>
        /// Delete doctor by id
        /// </summary>
        /// <param name="idDoctor">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Doctor deleted</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idDoctor}")]
        public async Task<ActionResult> DeleteDoctorAsync([FromRoute] int idDoctor)
        {
            try
            {
                await _repository.DeleteDoctorAsync(idDoctor);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("This doctor is in consultation or not exist, delete the consultation to delete the doctor");
            }
        }
    }
}
