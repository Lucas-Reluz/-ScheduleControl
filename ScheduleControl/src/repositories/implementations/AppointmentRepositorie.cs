using Microsoft.EntityFrameworkCore;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    /// <summary>
    /// <para>Resumo: Class responsible for implementing IAppointment</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 2.0</para>
    /// <para>Data: 20/08/2022</para>
    /// </summary>
    public class AppointmentRepositorie : IAppointment
    {
        #region Attributes
        private readonly ScheduleControlContext _context;
        #endregion

        public AppointmentRepositorie(ScheduleControlContext context)
        {
            _context = context;
        }
        /// <summary>
        /// <para>Summary: Asynchronous method that deletes a appointment</para>
        /// </summary>
        public async Task DeleteAppointmentAsync(int id)
        {
            _context.Appointments.Remove(await GetAppointmentByIdAsync(id));
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Summary: Asynchronous method to get all appointments</para>
        /// </summary>
        /// <return>List Query</return>
        public async Task<List<AppointmentModel>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments
                .Include(q => q.Doctor)
                .Include(q => q.Patient)
                .ToListAsync();
        }

        /// <summary>
        /// <para>Summary: Asynchronous method to get a appointment by Id </para>
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <return>QueryModel</return>
        public async Task<AppointmentModel> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(q => q.Doctor)
                .Include(q => q.Patient)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <summary>
        /// <para>Summary: Asynchronous method to create new appointment</para>
        /// </summary>
        /// <param name="appointment">NewQueryDTO</param>
        public async Task NewAppointmentAsync(NewAppointmentDTO appointment)
        {
            await _context.Appointments.AddAsync(new AppointmentModel
            {
                  Reason = appointment.Reason,
                  Data = appointment.Data,
                  Doctor = _context.Doctors.FirstOrDefault(d => d.Name == appointment.Doctor.Name),
                  Patient = _context.Patients.FirstOrDefault(p => p.Name == appointment.Patient.Name),
            });
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Summary: Asynchronous method to update a appointment</para>
        /// </summary>
        /// <param name="appointment">UpdateAppointmentDTO</param>
        public async Task UpdateAppointmentAsync(UpdateAppointmentDTO appointment)
        {
            var _query = await GetAppointmentByIdAsync(appointment.Id);
            _query.Data = appointment.Data;
            _query.Doctor = _context.Doctors.FirstOrDefault(d => d.Name == appointment.Doctor.Name);
            await _context.SaveChangesAsync();
        }
    }
}
