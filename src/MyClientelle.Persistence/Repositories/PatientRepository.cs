namespace Kampa.MyClientelle.Persistence.Repositories;

using ClientelleAPI.Repositories;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;
using Kampa.MyClientelle.Web.Shared.Dto;

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

  public async Task<GetPatientDto?> GetOne(long id)
  {
    var patient = await context.Patients.SingleOrDefaultAsync(x => x.Id == id);
    if (patient == null)
    {
      return null;
    }

    var result = new GetPatientDto
    {
      Id = patient.Id,
      FirstName = patient.FirstName,
      LastName = patient.LastName,
      Address = patient.Address,
      AFM = patient.AFM,
      AMKA = patient.AMKA,
      PhoneNumber = patient.PhoneNumber,
    };

    return result;
  }

  public async Task<List<GetPatientDto>> GetAll()
  {
    var patients = await context.Patients
      .Select(patient => new GetPatientDto
      {
        Id = patient.Id,
        FirstName = patient.FirstName,
        LastName = patient.LastName,
        Address = patient.Address,
        AFM = patient.AFM,
        AMKA = patient.AMKA,
        PhoneNumber = patient.PhoneNumber,
      })
      .ToListAsync();

    return patients;
  }

  public async Task<GetPatientDto> Create(CreatePatientDto patient)
  {
    var model = new Patient
    {
      FirstName = patient.FirstName,
      LastName = patient.LastName,
      Address = patient.Address,
      AFM = patient.AFM,
      AMKA = patient.AMKA,
      PhoneNumber = patient.PhoneNumber,
    };

    context.Patients.Add(model);
    await context.SaveChangesAsync();

    var result = new GetPatientDto
    {
      Id = model.Id,
      FirstName = model.FirstName,
      LastName = model.LastName,
      Address = model.Address,
      AFM = model.AFM,
      AMKA = model.AMKA,
      PhoneNumber = model.PhoneNumber,
    };

    return result;
  }

  public async Task<GetPatientDto?> Update(UpdatePatientDto patient)
  {
    var model = await context.Patients.SingleOrDefaultAsync(x => x.Id == patient.Id);
    if (model == null)
    {
      return null;
    }

    model.FirstName = patient.FirstName;
    model.LastName = patient.LastName;
    model.Address = patient.Address;
    model.PhoneNumber = patient.PhoneNumber;

    await context.SaveChangesAsync();

    var result = new GetPatientDto
    {
      Id = model.Id,
      FirstName = model.FirstName,
      LastName = model.LastName,
      Address = model.Address,
      AFM = model.AFM,
      AMKA = model.AMKA,
      PhoneNumber = model.PhoneNumber,
    };

    return result;
  }

  public async Task Delete(long id)
  {
    var patient = await context.Patients.SingleOrDefaultAsync(x => x.Id == id);
    if (patient == null)
    {
      return;
    }

    context.Patients.Remove(patient);
    await context.SaveChangesAsync();
  }
}
