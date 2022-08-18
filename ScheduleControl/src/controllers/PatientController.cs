using Microsoft.AspNetCore.Mvc;
using ScheduleControl.src.dtos;
using ScheduleControl.src.repositories;
using System;
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
        [HttpGet("id/{idPatient}")]
        public async Task<ActionResult> GetPatientById([FromRoute] int idPatient)
        {
            var patient = await _repository.GetPatientByIdAsync(idPatient);
            if (patient == null) return NotFound();
            return Ok(patient);
        }
        [HttpGet("email/{emailPatient}")]
        public async Task<ActionResult> GetPatientByEmail([FromRoute] string email)
        {
            var emailPatient = await _repository.GetPatientByEmailAsync(email);

            if (emailPatient == null) return NotFound();
            return Ok(emailPatient);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllDoctorsAsync()
        {
            var list = await _repository.GetAllPatientsAsync();

            if(list.Count < 1) return NotFound();
            return Ok(list);
        }
        [HttpDelete("delete/{idPatient}")]
        public async Task<ActionResult> DeletePatientAsync(int idPatient)
        {
            await _repository.DeletePatientAsync(idPatient);
            return NoContent();
        }
    }
}
