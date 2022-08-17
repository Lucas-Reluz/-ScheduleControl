using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleControl.src.models
{
    /// <summary>
    /// <para>Summary: Mirror class responsible for queries on the server</para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    [Table("tb_query")]
    public class QueryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason{ get; set; }

        [Required, StringLength(50)]
        public string Hours { get; set; }

        [Required, StringLength(50)]
        public string Data { get; set; }

        [ForeignKey("fk_doctor")]
        public DoctorModel Doctor { get; set; }

        [ForeignKey("fk_patient")]
        public PatientModel Patient { get; set; }
    }
}
