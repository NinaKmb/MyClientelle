using ClientelleAPI.Models;

namespace ClientelleAPI.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<patient>> Get();
        Task <patient> Get(int id);
        Task <patient> Create(patient patient);
        Task Update(patient patient);
        Task Delete(int id);
    }
}