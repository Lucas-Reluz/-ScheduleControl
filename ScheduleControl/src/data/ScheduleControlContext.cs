using Microsoft.EntityFrameworkCore;

namespace ScheduleControl.src.data
{
    /// <summary>
    /// <para>Summary: Context class, responsible for loading context and defining DbSets </para>
    /// <para>Created by: Lucas Reluz</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class ScheduleControlContext : DbContext
    {
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<QueryModel> Queries { get; set; }

        public ScheduleControlContext(DbContextOptions<ScheduleControlContext> opt) : base(opt)
        {

        }
    }
}
