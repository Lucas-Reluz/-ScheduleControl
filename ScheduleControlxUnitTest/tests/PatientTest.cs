using ScheduleControl.src.controllers;
using ScheduleControl.src.dtos;
using ScheduleControl.src.models;
using ScheduleControl.src.repositories;
using ScheduleControl.src.repositories.implementations;
using System;
using Xunit;

namespace ScheduleControlxUnitTest
{
    public class PatientTest
    {
        [Fact(DisplayName = "Should successfully return a different name")]
        public void CreatePatientReturnNotEqualPatientName()
        {
            var CreatePatient = new NewPatientDTO("Lucas", "lucas@email.com");

            Assert.NotEqual("Mauricio", CreatePatient.Name);
        }

        [Fact(DisplayName = "Should successfully return a patient email")]
        public void CreatePatientReturnPatientEmail()
        {

            var CreatePatient = new NewPatientDTO("Julio Fernandez", "julio@email.com");
            Assert.Equal("julio@email.com", CreatePatient.Email);
        }
    }
}
