namespace ClientelleAPI.Repositories;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

[CLSCompliant(false)]
public class PatientRepository : IPatientRepository
{
  private readonly MyClientelleDbContext context;

  public PatientRepository(MyClientelleDbContext context)
  {
    this.context = context;
  }

  public async Task<Patient> Create(Patient patient)
  {
    context.Patients.Add(patient);
    await context.SaveChangesAsync();

    return patient;
  }

  public async Task Delete(int id)
  {
    var patientToDelete = await context.Patients.FindAsync(id);
    context.Patients.Remove(patientToDelete);
    await context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Patient>> Get()
  {
    return await context.Patients.ToListAsync();
  }

  public async Task<Patient> Get(int id)
  {
    return await context.Patients.FindAsync(id);
  }

  public async Task Update(Patient patient)
  {
    context.Entry(patient).State = EntityState.Modified;
    await context.SaveChangesAsync();
  }
}
