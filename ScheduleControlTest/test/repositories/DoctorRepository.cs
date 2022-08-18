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
    public class DoctorRepository
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
                        "Neurologista"
                        ));
            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Porcha",
                        "Enfermeiro"
                        ));
            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Thiago",
                        "Cirurgião"
                        ));
            await _repository.NewDoctorAsync(
                    new NewDoctorDTO(
                        "Oliveira",
                        "Pediatria"
                        ));
            Assert.AreEqual(4, _context.Doctors.Count());
        }
        [TestMethod]
        public async Task GetDoctorReturnDoctorOccupation()
        {
            var opt = new DbContextOptionsBuilder<ScheduleControlContext>()
               .UseInMemoryDatabase(databaseName: "db_schedulecontrol")
               .Options;
            _context = new ScheduleControlContext(opt);
            _repository = new DoctorRepositorie(_context);

            await _repository.NewDoctorAsync(
                new NewDoctorDTO(
                    "Bruninho João",
                    "Enfermeiro"
                    ));

            var doctor = await _repository.GetDoctorByIdAsync(1);
            Assert.IsNotNull(doctor);
            Assert.AreEqual("Enfermeiro", doctor);
        }
    }
}
