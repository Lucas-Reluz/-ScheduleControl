using System.ComponentModel.DataAnnotations;

namespace ScheduleControl.src.dtos
{
    public class QueryDTO
    {
        [Required, StringLength(200)]
        public string Reason { get; set; }

        [Required]
        public int Hours { get; set; }

        [Required]
        public string Doctor { get; set; }

        [Required]
        public string Patient { get; set; }

        public QueryDTO(string reason, int hours, string doctor, string patient)
        {
            Reason = reason;
            Hours = hours;
            Doctor = doctor;
            Patient = patient;
        }
    }
}
