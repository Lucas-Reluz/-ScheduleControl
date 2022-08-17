using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories
{
    /// <summary>
    /// <para>Summary: Responsible for representing patient CRUD actions</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public interface IPatient
    {
        Task NewPatientAsync(NewPatientDTO patient);
        Task DeletePatientAsync(int id);

        Task<List<PatientModel>> GetAllPatientsAsync();
        Task<PatientModel>GetPatientByEmailAsync(string email);

    }
}
