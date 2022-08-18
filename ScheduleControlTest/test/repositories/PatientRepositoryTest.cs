using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.repositories;
using ScheduleControl.src.repositories.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleControlTest.test.repositories
{
    [TestClass]
    public class PatientRepositoryTest
    {
        private ScheduleControlContext _context;
        private IPatient _repository;

        [TestMethod]
        public async Task CreateFourPatientsInDatabaseReturnFourPatients()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
                .UseInMemoryDatabase(databaseName: "db_schedulecontrol")
                .Options;
                _context = new ScheduleControlContext(opt);
            _repository = new PatientRepositorie(_context);
  

                await _repository.NewPatientAsync(
                    new NewPatientDTO(
                        "Pirlo",
                        "pirlo@email.com"
                        ));
                await _repository.NewPatientAsync(
                    new NewPatientDTO(
                        "Augusto Braga",
                        "augusto@email.com"
                        ));
                await _repository.NewPatientAsync(
                    new NewPatientDTO(
                        "Cleiton",
                        "cleiton@email.com"
                        ));
                await _repository.NewPatientAsync(
                    new NewPatientDTO(
                        "Marcelo Moreno",
                        "marcelomoreno@email.com"
                        ));
                Assert.AreEqual(4, _context.Patients.Count());
        }

        [TestMethod]
        public async Task GetPatientByEmailReturnNotNull()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
                .UseInMemoryDatabase(databaseName: "db_schedulecontrol")
                .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new PatientRepositorie(_context);


            await _repository.NewPatientAsync(
                new NewPatientDTO(
                    "Kleber Moreira",
                    "kleber@email.com"
                    ));

            var patient = _repository.GetPatientByEmailAsync("kleber@email.com");
            Assert.IsNotNull(patient);
        }
        
        [TestMethod]
        public async Task GetPatientByIdReturnNotNull()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
                .UseInMemoryDatabase(databaseName: "db_schedulecontrol")
                .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new PatientRepositorie(_context);


            await _repository.NewPatientAsync(
                new NewPatientDTO(
                    "Pele Roberto",
                    "pele@email.com"
                    ));

            var patientU = _repository.GetPatientByIdAsync(1);
            
            Assert.IsNotNull(patientU);
            Assert.AreEqual("Pele Roberto", patientU);
        }
    }
}
