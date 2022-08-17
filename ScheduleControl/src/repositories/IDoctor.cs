using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories
{
    /// <summary>
    /// <para>Summary: Responsible for representing doctor CRUD actions</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public interface IDoctor
    {
        Task NewDoctorAsync(NewDoctorDTO dto);
        Task UpdateDoctorAsync(UpdateDoctorDTO dto);
        Task DeleteDoctorAsync(int id);
        Task<List<DoctorModel>> GetAllDoctors();
        Task<DoctorModel> GetDoctorByIdAsync(int id);
        Task<DoctorModel> GetDoctorByOccupationAreaAsync(string occupationArea);
    }
}
