using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleControl.src.models
{
    /// <summary>
    /// <para>Summary: Mirror class responsible for doctors on the server</para>
    /// <para>Created by: Matheus Correia</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
   [Table("tb_doctors")]
    public class DoctorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength()]
    }
}
