using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using ScheduleControl.src.repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.src.controllers
{
    [ApiController]
    [Route("api/Patient")]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        #region Attributes
        private readonly IPatient _repository;
        #endregion

        public PatientController(IPatient patient)
        {
            _repository = patient;
        }

        /// <summary>
        /// Create New Patient
        /// </summary>
        /// <param name="patient">NewPatientDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Requisition example:
        ///
        ///     POST /api/Patient
        ///     {
        ///        "name": "Marcelo",
        ///        "email": "marcelo@email.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="201"> Return created Patient</response>
        /// <response code="400"> request error </response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PatientModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Register")]
        public async Task<ActionResult> NewPatientAsync([FromBody] NewPatientDTO patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _repository.NewPatientAsync(patient);
                return Created($"api/Patient", patient);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        /// <summary>
        /// Get Patient by id
        /// </summary>
        /// <param name="idPatient">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return Patient</response>
        /// <response code="404">Patient does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idPatient}")]
        public async Task<ActionResult> GetPatientById([FromRoute] int idPatient)
        {
            var patient = await _repository.GetPatientByIdAsync(idPatient);
            if (patient == null) return NotFound();
            return Ok(patient);
        }
        /// <summary>
        /// Get patient by Email
        /// </summary>
        /// <param name="emailPatient">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Return the Patient</response>
        /// <response code="404">Email does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PatientModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("email/{emailPatient}")]
        public async Task<ActionResult> GetPatientByEmail([FromRoute] string emailPatient)
        {
            var patientE = await _repository.GetPatientByEmailAsync(emailPatient);

            if (patientE == null) return NotFound();
            return Ok(patientE);
        }
        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Patient list</response>
        /// <response code="204">Empty list</response>
        [HttpGet]
        public async Task<ActionResult> GetAllPatientsAsync()
        {
            var list = await _repository.GetAllPatientsAsync();

            if(list.Count < 1) return NotFound();
            return Ok(list);
        }
        /// <summary>
        /// Delete patient by id
        /// </summary>
        /// <param name="idPatient">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Patient deleted</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("delete/{idPatient}")]
        public async Task<ActionResult> DeletePatientAsync(int idPatient)
        {
            try
            {
                await _repository.DeletePatientAsync(idPatient);
                return NoContent();
            }
            catch(Exception)
            {
                return BadRequest("This patient is in consultation or not exist, delete the consultation to delete the patient");
            }
        }
    }
}
