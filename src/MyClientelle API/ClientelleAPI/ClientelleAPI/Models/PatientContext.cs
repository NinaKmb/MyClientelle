using Microsoft.EntityFrameworkCore;

namespace ClientelleAPI.Models
{
    public class PatientContext : DbContext
    {
        internal object patient;

        public PatientContext( DbContextOptions<PatientContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet <patient> Patient { get; set; }
    }
}
