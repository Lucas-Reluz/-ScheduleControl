using Microsoft.EntityFrameworkCore;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    /// <summary>
    /// <para>Resumo: Class responsible for implementing IDoctor</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 18/08/2022</para>
    /// </summary>
    public class DoctorRepositorie : IDoctor
    {
        #region Attributes
        private readonly ScheduleControlContext _context;
        #endregion

        public DoctorRepositorie(ScheduleControlContext context)
        {
            _context = context;
        }
        /// <summary>
        /// <para>Summary: Asynchronous method that deletes a doctor</para>
        /// </summary>
        public async Task DeleteDoctorAsync(int id)
        {
            _context.Doctors.Remove(await GetDoctorByIdAsync(id));
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to get all doctors</para>
        /// </summary>
        /// <return>List Doctor</return>
        public async Task<List<DoctorModel>> GetAllDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        /// <summary>
        /// <para>Resumo: Asynchronous method to get a doctor by Id </para>
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <return>DoctorModel</return>
        public async Task<DoctorModel> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to get a doctor by occupation area</para>
        /// </summary>
        /// <param name="occupationArea">Hours of Query</param>
        /// <return>DoctorModel</return>
        public async Task<List<DoctorModel>> GetDoctorByOccupationAreaAsync(string occupationArea)
        {
            return await _context.Doctors.Where(d => d.OccupationArea.Contains(occupationArea)).ToListAsync();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to create new Doctor</para>
        /// </summary>
        /// <param name="doctor">NewQueryDTO</param>
        public async Task NewDoctorAsync(NewDoctorDTO doctor)
        {
            await _context.Doctors.AddAsync(new DoctorModel
            {
                Name = doctor.Name,
                OccupationArea = doctor.OccupationArea,
                ConsultationTime = doctor.ConsultationTime
            });
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to update a doctor</para>
        /// </summary>
        /// <param name="doctor">UpdateQueryDTO</param>
        public async Task UpdateDoctorAsync(UpdateDoctorDTO doctor)
        {
            var _doctor = await GetDoctorByIdAsync(doctor.Id);
            _doctor.OccupationArea = doctor.OccupationArea;
            _context.Update(_doctor);
            await _context.SaveChangesAsync();
        }
    }
}
