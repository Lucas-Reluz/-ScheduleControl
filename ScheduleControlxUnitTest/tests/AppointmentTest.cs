using ScheduleControl.src.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleControlxUnitTest.tests
{
    public class AppointmentTest
    {
        [Fact(DisplayName = "Should successfully return a different reason")]
        public void CreateDoctorReturnNotEqualDoctorName()
        {
            var CreateAppointment = new NewAppointmentDTO("Dor muito forte", DateTime.Now, new NewDoctorDTO("Mauro", "cirurgião", 1), new NewPatientDTO("Flaivo", "flavio@email.com"));

            Assert.NotEqual("Consulta de rotina", CreateAppointment.Reason);
        }
        [Fact(DisplayName = "Should successfully return a doctor name")]
        public void CreateAppointmentReturnDoctorName()
        {
            var CreateAppointment = new NewAppointmentDTO("Dor muito forte", DateTime.Now, new NewDoctorDTO("Mauro", "cirurgião", 1), new NewPatientDTO("Flaivo", "flavio@email.com"));

            Assert.Equal("Mauro", CreateAppointment.Doctor.Name);
        }
    }
}
