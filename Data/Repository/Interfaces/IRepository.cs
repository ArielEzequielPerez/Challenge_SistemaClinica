using SistemasClinica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemasClinica.Data.Repository.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Professional>> GetProfessionalAsync();
        Task<IEnumerable<Consult>> GetConsultsAsync();
        Task<IEnumerable<Patient>> GetPatientAsync();
        Task<Professional> GetProfessionalByIdAsync(int id);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Consult>> GetConsultsByIdAsync(int id);
    }
}
