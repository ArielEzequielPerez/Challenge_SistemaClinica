using Microsoft.EntityFrameworkCore;
using SistemasClinica.Data.Repository.Interfaces;
using SistemasClinica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemasClinica.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly ClinicaDbContext _context;

        public Repository(ClinicaDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<IEnumerable<Patient>> GetPatientAsync()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }
        public async Task<IEnumerable<Professional>> GetProfessionalAsync()
        {
            return await _context.Professionals.ToListAsync();
        }
        public async Task<Professional> GetProfessionalByIdAsync(int id)
        {
            return await _context.Professionals.FindAsync(id);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<Consult>> GetConsultsAsync()
        {
            return await _context.Consults.ToListAsync();
        }

        public async Task<IEnumerable<Consult>> GetConsultsByIdAsync(int id)
        {
            return (IEnumerable<Consult>)await _context.Consults.FindAsync(id);
        }
    }
}
