using Microsoft.EntityFrameworkCore;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    /// <summary>
    /// <para>Resumo: Class responsible for implementing IPatient</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 18/08/2022</para>
    /// </summary>
    public class PatientRepositorie : IPatient
    {
        #region Attributes
        private readonly ScheduleControlContext _context;
        #endregion

        public PatientRepositorie(ScheduleControlContext context)
        {
            _context = context;
        }
        /// <summary>
        /// <para>Summary: Asynchronous method that deletes a patient</para>
        /// </summary>
        public async Task DeletePatientAsync(int id)
        {
            _context.Patients.Remove(await GetPatientByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Asynchronous method to get all patients</para>
        /// </summary>
        /// <return>List Query</return>
        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {
            return await _context.Patients.Include(p => p.MyAppointments).ToListAsync();
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to get a patient for email</para>
        /// </summary>
        /// <param name="email">Hours of Query</param>
        /// <return>PatientModel</return>
        public async Task<PatientModel> GetPatientByEmailAsync(string email)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to get a patient by Id </para>
        /// </summary>
        /// <param name="id">Id do usuario</param>
        /// <return>PatientModel</return>
        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }
        /// <summary>
        /// <para>Resumo: Asynchronous method to create new Patient</para>
        /// </summary>
        /// <param name="patient">NewQueryDTO</param>
        public async Task NewPatientAsync(NewPatientDTO patient)
        {
            var patientRegistered = await GetPatientByEmailAsync(patient.Email);
            if (patientRegistered != null) throw new Exception("Patient already registered");
            await _context.Patients.AddAsync(new PatientModel
            {
                Name = patient.Name,
                Email = patient.Email,
            });
            await _context.SaveChangesAsync();
        }
    }
}
