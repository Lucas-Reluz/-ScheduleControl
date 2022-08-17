using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    public class DoctorRepositorie : IDoctor
    {
        public Task DeleteDoctorAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<DoctorModel>> GetAllDoctors()
        {
            throw new System.NotImplementedException();
        }

        public Task<DoctorModel> GetDoctorByOccupationAreaAsync(string occupationArea)
        {
            throw new System.NotImplementedException();
        }

        public Task NewDoctorAsync(NewDoctorDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateDoctorAsync(UpdateDoctorDTO dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
