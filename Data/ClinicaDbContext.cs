using Microsoft.EntityFrameworkCore;
using SistemasClinica.Models;

namespace SistemasClinica.Data
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options)
        {  
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consult> Consults { get; set; }
        public DbSet<Professional> Professionals { get; set; }
    }
}
