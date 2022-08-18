using Microsoft.EntityFrameworkCore;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    public class DoctorRepositorie : IDoctor
    {
        #region Attributes
        private readonly ScheduleControlContext _context;
        #endregion

        public DoctorRepositorie(ScheduleControlContext context)
        {
            _context = context;
        }

        public async Task DeleteDoctorAsync(int id)
        {
            _context.Doctors.Remove(await GetDoctorByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<DoctorModel>> GetAllDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<DoctorModel> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DoctorModel>> GetDoctorByOccupationAreaAsync(string occupationArea)
        {
            return await _context.Doctors.Where(d => d.OccupationArea.Contains(occupationArea)).ToListAsync();
        }

        public async Task NewDoctorAsync(NewDoctorDTO doctor)
        {
            await _context.Doctors.AddAsync(new DoctorModel
            {
                Name = doctor.Name,
                OccupationArea = doctor.OccupationArea,
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDTO doctor)
        {
            var _doctor = await GetDoctorByIdAsync(doctor.Id);
            _doctor.OccupationArea = doctor.OccupationArea;
            await _context.SaveChangesAsync();
        }
    }
}
