using System.ComponentModel.DataAnnotations;

namespace ScheduleControl.src.dtos
{
    /// <summary>
    /// <para>Summary: Mirror class responsible for creating new patients</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class NewPatientDTO
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        public NewPatientDTO(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
