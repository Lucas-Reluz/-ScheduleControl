using ScheduleControl.src.models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleControl.src.dtos
{
    /// <summary>
    /// <para>Summary: Mirror class responsible for creating new appointments</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class NewAppointmentDTO
    {
        [Required, StringLength(200)]
        public string Reason { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public NewDoctorDTO Doctor { get; set; }

        [Required]
        public NewPatientDTO Patient { get; set; }

        public NewAppointmentDTO(string reason, DateTime data, NewDoctorDTO doctor, NewPatientDTO patient)
        {
            Reason = reason;
            Data = data;
            Doctor = doctor;
            Patient = patient;
        }
    }
    /// <summary>
    /// <para>Summary: Mirror class responsible for updating appointments</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class UpdateAppointmentDTO
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public DateTime Data { get; set; }

        public NewDoctorDTO Doctor { get; set; }

        public UpdateAppointmentDTO(int id, DateTime data, NewDoctorDTO doctor)
        {
            Id = id;
            Data = data;
            Doctor = doctor;
        }
    }
}
