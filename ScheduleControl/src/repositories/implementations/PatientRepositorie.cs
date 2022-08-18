using Microsoft.EntityFrameworkCore;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    public class PatientRepositorie : IPatient
    {
        #region Attributes
        private readonly ScheduleControlContext _context;
        #endregion

        public PatientRepositorie(ScheduleControlContext context)
        {
            _context = context;
        }

        public async Task DeletePatientAsync(int id)
        {
            _context.Patients.Remove(await GetPatientByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<PatientModel> GetPatientByEmailAsync(string email)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<PatientModel> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

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
