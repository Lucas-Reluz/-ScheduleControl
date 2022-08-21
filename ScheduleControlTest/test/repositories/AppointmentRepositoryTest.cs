using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleControl.src.data;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
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
    public class AppointmentRepositoryTest
    {
        private ScheduleControlContext _context;
        private IAppointment _repository;
        private IDoctor _repositoryD;
        private IPatient _repositoryP;

        [TestMethod]
        public async Task CreateTwoQueriesInDatabaseReturnTwoQueries()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
                .UseInMemoryDatabase(databaseName: "db_schedulecontrol1")
                .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new AppointmentRepositorie(_context);
            _repositoryD = new DoctorRepositorie(_context);
            _repositoryP = new PatientRepositorie(_context);

            await _repository.NewAppointmentAsync(
           new NewAppointmentDTO(
               "Dor no ombro",
               DateTime.Now,
               new NewDoctorDTO(
                   "Cleiton Moreno",
                   "Pediatria",
                   1
                   ),
               new NewPatientDTO(
                   "Augusto Braga",
                   "augusto@email.com"
                   )
               ));
            Assert.AreEqual(1, _context.Appointments.Count());
        }
        [TestMethod]
        public async Task GetQueryByIdReturnNotNull()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
             .UseInMemoryDatabase(databaseName: "db_schedulecontrol2")
             .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new AppointmentRepositorie(_context);
            _repositoryD = new DoctorRepositorie(_context);
            _repositoryP = new PatientRepositorie(_context);

            var query = await _repository.GetAppointmentByIdAsync(1);
            Assert.IsNotNull(query);
        }
        [TestMethod]
        public async Task GetQueryByIdReturnPatientName()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
            .UseInMemoryDatabase(databaseName: "db_schedulecontrol3")
            .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new AppointmentRepositorie(_context);
            _repositoryD = new DoctorRepositorie(_context);
            _repositoryP = new PatientRepositorie(_context);

            await _repository.NewAppointmentAsync(
            new NewAppointmentDTO(
                "Dor no ombro",
                DateTime.Now,
                new NewDoctorDTO(
                    "Cleiton Moreno",
                    "Pediatria",
                    1
                    ),
                new NewPatientDTO(
                    "Leandro Pereira",
                    "augusto@email.com"
                    )
                ));
            var query = await _repository.GetAppointmentByIdAsync(1);
            Assert.AreEqual("Leandro Pereira", query.Patient.Name);
        }
        [TestMethod]
        public async Task GetQueryByIdReturnReason()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
           .UseInMemoryDatabase(databaseName: "db_schedulecontrol4")
           .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new AppointmentRepositorie(_context);
            _repositoryD = new DoctorRepositorie(_context);
            _repositoryP = new PatientRepositorie(_context);

            await _repository.NewAppointmentAsync(
                new NewAppointmentDTO(
                    "Dor no ombro",
                    DateTime.Now,
                    new NewDoctorDTO(
                        "Cleiton Moreno",
                        "Pediatria",
                        1
                        ),
                    new NewPatientDTO(
                        "Augusto Braga",
                        "augusto@email.com"
                        )
                    ));
            var query = await _repository.GetAppointmentByIdAsync(1);
            Assert.AreEqual("Dor no Ombro", query.Reason);
        }
    }
}
