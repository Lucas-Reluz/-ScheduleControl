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
    public class DoctorRepositoryTest
    {
        private ScheduleControlContext _context;
        private IDoctor _repository;

        [TestMethod]
        public async Task CreateFourDoctorInDatabaseReturnFourDoctors()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
               .UseInMemoryDatabase(databaseName: "db_schedulecontrol")
               .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new DoctorRepositorie(_context);

            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Paulo",
                        "Neurologista",
                        1
                        ));
            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Porcha",
                        "Enfermeiro",
                        1
                        ));
            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Thiago",
                        "Cirurgião",
                        2
                        ));
            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Oliveira",
                        "Pediatria",
                        1
                        ));
            Assert.AreEqual(4, _context.Doctors.Count());
        }
        [TestMethod]
        public async Task GetDoctorByIdReturnDoctorName()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
               .UseInMemoryDatabase(databaseName: "db_schedulecontrol2")
               .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new DoctorRepositorie(_context);

            await _repository.NewDoctorAsync(
                new NewDoctorDTO(
                    "Bruninho João",
                    "Enfermeiro",
                    1
                    ));

            var doctor = await _repository.GetDoctorByIdAsync(1);
            Assert.IsNotNull(doctor);
            Assert.AreEqual("Bruninho João", doctor.Name);
        }
        [TestMethod]
        public async Task GetDoctorByIdReturnNotEqualOccupationArea()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
              .UseInMemoryDatabase(databaseName: "db_schedulecontrol3")
              .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new DoctorRepositorie(_context);

            await _repository.NewDoctorAsync(
                new NewDoctorDTO(
                    "Kleber Augusto",
                    "Pediatra",
                    1
                    ));
            var doctor = await _repository.GetDoctorByIdAsync(1);
            Assert.IsNotNull(doctor);
            Assert.AreNotEqual("Medico Geral", doctor.OccupationArea);
        }
        [TestMethod]
        public async Task GetDoctorByIdReturnConsultationTime()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
              .UseInMemoryDatabase(databaseName: "db_schedulecontrol4")
              .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new DoctorRepositorie(_context);

            await _repository.NewDoctorAsync(
               new NewDoctorDTO(
                   "Alberto Morales",
                   "Fisioterapeuta",
                   3
                   ));
            var doctor = await _repository.GetDoctorByIdAsync(1);
            Assert.IsNotNull(doctor);
            Assert.AreEqual(3, doctor.ConsultationTime);
        }
    }
}
