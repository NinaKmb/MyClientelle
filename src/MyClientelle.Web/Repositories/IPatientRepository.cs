namespace ClientelleAPI.Repositories;

using Kampa.MyClientelle.Persistence.Model;

public interface IPatientRepository
{
  Task<IEnumerable<Patient>> Get();

  Task<Patient> Get(int id);

  Task<Patient> Create(Patient patient);

  Task Update(Patient patient);

  Task Delete(int id);
}
