using System.ComponentModel.DataAnnotations;

namespace ScheduleControl.src.dtos
{
    /// <summary>
    /// <para>Summary: Mirror class responsible for creating new doctors</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class NewDoctorDTO
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string OccupationArea { get; set; }
        public int ConsultationTime { get; set; }

        public NewDoctorDTO(string name, string occupationArea, int consultationTime)
        {
            Name = name;
            OccupationArea = occupationArea;
            ConsultationTime = consultationTime;
        }
    }

    /// <summary>
    /// <para>Summary: Mirror class responsible for updating doctors</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class UpdateDoctorDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string OccupationArea { get; set; }

        public UpdateDoctorDTO(int id, string occupationArea)
        {
            Id = id;
            OccupationArea = occupationArea;
        }
    }
}
