namespace Kampa.MyClientelle.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kampa.MyClientelle.Persistence.Model;
using Kampa.MyClientelle.Web.Models.Dto;
using Kampa.MyClientelle.Web.Models.Repositories;

using Microsoft.EntityFrameworkCore;

public class ExaminationRepository : IExaminationRepository
{
  private readonly MyClientelleDbContext context;

  public ExaminationRepository(MyClientelleDbContext context) => this.context = context;

  public async Task<GetExaminationDto> Create(CreateExaminationDto model)
  {
    ArgumentNullException.ThrowIfNull(model);

    var appointment = await context.Appointments.SingleOrDefaultAsync(x => x.Id == model.Appointment.Id);
    var patient = await context.Patients.SingleOrDefaultAsync(x => x.Id == model.Patient.Id);
    var exam = new Examination { Appointment = appointment!, Patient = patient!, Exam = model.Exam };

    context.Examination.Add(exam);
    await context.SaveChangesAsync();

    var dto = new GetExaminationDto()
    {
      Id = exam.Id, Appointment = model.Appointment, Patient = model.Patient, Exam = exam.Exam,
    };

    return dto;
  }

  public async Task<GetExaminationDto> GetOne(long id)
  {
    var examination = await context.Examination.SingleOrDefaultAsync(x => x.Id == id);
    ArgumentNullException.ThrowIfNull(examination);

    // TODO: Map GetPatientDto and GetAppointmentDto
    var result = new GetExaminationDto { Id = examination.Id, Exam = examination.Exam };

    return result;
  }

  /// <inheritdoc />
  public async Task<List<GetExaminationDto>> GetAll()
  {
    var examinations = await context.Examination
      .Select(x => new GetExaminationDto { Id = x.Id, Exam = x.Exam })
      .ToListAsync();

    return examinations;
  }

  /// <inheritdoc />
  public async Task<GetExaminationDto> Update(long id, UpdateExaminationDto model)
  {
    ArgumentNullException.ThrowIfNull(model);

    var examination = await context.Examination.SingleOrDefaultAsync(x => x.Id == id);
    ArgumentNullException.ThrowIfNull(examination);

    examination.Exam = model.Exam;
    var patient = await context.Patients.SingleOrDefaultAsync(x => x.Id == model.Patient.Id);
    ArgumentNullException.ThrowIfNull(patient);

    examination.Patient = patient;

    // TODO: Map GetAppoitmentDto
    var dto = new GetExaminationDto { Patient = model.Patient, Exam = examination.Exam, };
    return dto;
  }

  public async Task Delete(long id)
  {
    var examination = await context.Examination.SingleOrDefaultAsync(x => x.Id == id);
    ArgumentNullException.ThrowIfNull(examination);

    context.Examination.Remove(examination);
    await context.SaveChangesAsync();
  }
}
