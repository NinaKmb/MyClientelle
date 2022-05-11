namespace Kampa.MyClientelle.Persistence.Repositories;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using Kampa.MyClientelle.Web.Models.Dto;
using Kampa.MyClientelle.Web.Models.Repositories;

public class PatientRepository : IPatientRepository
{
  private readonly MyClientelleDbContext context;

  public PatientRepository(MyClientelleDbContext context)
  {
    this.context = context;
  }

  public async Task<GetPatientDto> GetOne(long id)
  {
    var patient = await context.Patients.SingleOrDefaultAsync(x => x.Id == id);
    ArgumentNullException.ThrowIfNull(patient);

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

  public async Task<GetPatientDto> Create(CreatePatientDto model)
  {
    ArgumentNullException.ThrowIfNull(model);

    var entity = new Patient
    {
      FirstName = model.FirstName,
      LastName = model.LastName,
      Address = model.Address,
      AFM = model.AFM,
      AMKA = model.AMKA,
      PhoneNumber = model.PhoneNumber,
    };

    context.Patients.Add(entity);
    await context.SaveChangesAsync();

    var result = new GetPatientDto
    {
      Id = entity.Id,
      FirstName = entity.FirstName,
      LastName = entity.LastName,
      Address = entity.Address,
      AFM = entity.AFM,
      AMKA = entity.AMKA,
      PhoneNumber = entity.PhoneNumber,
    };

    return result;
  }

  public async Task<GetPatientDto?> Update(long id, UpdatePatientDto model)
  {
    ArgumentNullException.ThrowIfNull(model);

    var entity = await context.Patients.SingleOrDefaultAsync(x => x.Id == id);
    ArgumentNullException.ThrowIfNull(entity);

    entity.FirstName = model.FirstName;
    entity.LastName = model.LastName;
    entity.Address = model.Address;
    entity.PhoneNumber = model.PhoneNumber;

    await context.SaveChangesAsync();

    var result = new GetPatientDto
    {
      Id = entity.Id,
      FirstName = entity.FirstName,
      LastName = entity.LastName,
      Address = entity.Address,
      AFM = entity.AFM,
      AMKA = entity.AMKA,
      PhoneNumber = entity.PhoneNumber,
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
