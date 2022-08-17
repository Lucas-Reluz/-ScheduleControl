using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.src.repositories.implementations
{
    public class PatientRepositorie : IPatient
    {
        public Task DeletePatientAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<PatientModel>> GetAllPatientsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<PatientModel> GetPatientByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task NewPatientAsync(NewPatientDTO patient)
        {
            throw new System.NotImplementedException();
        }
    }
}
