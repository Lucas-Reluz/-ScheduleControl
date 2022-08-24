using ScheduleControl.src.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleControlxUnitTest.tests
{
    public class DoctorTest
    {
        [Fact(DisplayName = "Should successfully return a different doctor name")]
        public void CreateDoctorReturnNotEqualDoctorName()
        {
            var CreateDoctor = new NewDoctorDTO("Pedro", "Cirurgião", 1);

            Assert.NotEqual("Flávio", CreateDoctor.Name);
        }
        [Fact(DisplayName = "Should successfully return a doctor name")]
        public void CreateDoctorReturnDoctorName()
        {
            var CreateDoctor = new NewDoctorDTO("Lauro", "Neurologista", 3);

            Assert.Equal("Lauro", CreateDoctor.Name);
        }
    }
}
