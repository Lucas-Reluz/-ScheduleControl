using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories
{
    /// <summary>
    /// <para>Summary: Responsible for representing query CRUD actions</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public interface IAppointment
    {
        Task NewAppointmentAsync(NewAppointmentDTO appointment);
        Task UpdateAppointmentAsync(UpdateAppointmentDTO appointment);
        Task<AppointmentModel> GetAppointmentByIdAsync(int id);
        Task DeleteAppointmentAsync(int id);
        Task<List<AppointmentModel>> GetAllAppointmentsAsync();

    }
}
