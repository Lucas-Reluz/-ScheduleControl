using System.ComponentModel.DataAnnotations;

namespace ScheduleControl.src.dtos
{
    /// <summary>
    /// <para>Summary: Mirror class responsible for creating new queries</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class QueryDTO
    {
        [Required, StringLength(200)]
        public string Reason { get; set; }

        [Required, StringLength(50)]
        public string Hours { get; set; }

        [Required]
        public string Doctor { get; set; }

        [Required]
        public string Patient { get; set; }

        public QueryDTO(string reason, string hours, string doctor, string patient)
        {
            Reason = reason;
            Hours = hours;
            Doctor = doctor;
            Patient = patient;
        }
    }
}
