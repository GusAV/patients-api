using Microsoft.EntityFrameworkCore;

namespace CmdApi.Models
{
    public class PatientsContext : DbContext
    {
        public PatientsContext(DbContextOptions<PatientsContext> options) : base(options)
        {

        }

        public DbSet<Patient> PatientItems { get; set; }
    }
}