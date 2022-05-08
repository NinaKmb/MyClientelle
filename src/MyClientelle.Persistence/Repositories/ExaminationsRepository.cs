namespace Kampa.MyClientelle.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[CLSCompliant(false)]
public class ExaminationsRepository :
{
  private readonly MyClientelleDbContext context;

  public ExaminationsRepository(MyClientelleDbContext context)
  {
    this.context = context;
  }

  public async Task<GetExaminationDto> GetOne(long id)
  {
    var examinations = await context.Examinations.SingleOrDefaultAsync(x => x.Id == id);
    if (examinations == null)
    {
      return null;
    }

    var result = new GetExaminationsDto
    {
     examination = examinations.examination
    };

    return result;
  }

  public async Task<List<GetExaminationsDto>> GetAll()
  {
    var examinations = await context.Examinations
      .Select(examinations => new GetExaminationsDto
      {
        examination = examinations.examination
      })
      .ToListAsync();

    return examination;
  }

  public async Task<GetExaminationsDto> Create(CreateExaminationsDto examinations)
  {
    var model = new exam
    {
      examination = examinations.examination
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
