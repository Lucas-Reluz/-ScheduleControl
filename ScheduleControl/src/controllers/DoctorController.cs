using Microsoft.AspNetCore.Mvc;
using ScheduleControl.src.dtos;
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

        [HttpPost("Register")]
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
        [HttpGet("id/{idDoctor}")]
        public async Task<ActionResult> GetDoctorById([FromRoute] int idDoctor)
        {
            var doctor= await _repository.GetDoctorByIdAsync(idDoctor);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDoctorsAsync()
        {
            var list = await _repository.GetAllDoctors();

            if (list.Count < 1) return NotFound();
            return Ok(list);
        }

        [HttpGet("occupationArea")]
        public async Task<ActionResult> GetDoctorByOccupationAreaAsync([FromQuery] string occupationArea)
        {
            var occupation = await _repository.GetDoctorByOccupationAreaAsync(occupationArea);

            if (occupation.Count < 1) return NoContent();
            return Ok(occupation);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctorAsync([FromBody] UpdateDoctorDTO doctor)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateDoctorAsync(doctor);

            return Ok(doctor);
        }

        [HttpDelete("delete/{idDoctor}")]
        public async Task<ActionResult> DeleteDoctorAsync([FromRoute] int idDoctor)
        {
            await _repository.DeleteDoctorAsync(idDoctor);
            return NoContent();
        }
    }
}
