namespace Kampa.MyClientelle.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

using Kampa.MyClientelle.Persistence.Model;
using Kampa.MyClientelle.Web.Shared;
using Kampa.MyClientelle.Web.Shared.Repositories;

using Microsoft.EntityFrameworkCore;

public class AppointmentDatabaseRepository : IAppointmentRepository
{
  MyClientelleDbContext ctx;

  public AppointmentDatabaseRepository(MyClientelleDbContext ctx)
  {
    this.ctx = ctx;
  }

  public async Task<GetAppointmentDto> Create(CreateAppointmentDto model)
  {
    var patient = await ctx.Patients.SingleOrDefaultAsync(x => x.Id == model.Patient.Id);
    var appointment = new Appointment
    {
      Date = model.DateTime,
      Patient = patient,
    };

    ctx.Appointments.Add(appointment);
    await ctx.SaveChangesAsync();

    return new GetAppointmentDto
    {

    };
  }

  public Task Delete(long id) => throw new NotImplementedException("Appointment has been Succesfully Deleted");

  public Task<List<GetAppointmentDto>> GetAll() => throw new NotImplementedException("List of appointments");

  public Task<GetAppointmentDto> GetOne(long id) => throw new NotImplementedException("Type a new appointment");

  public Task<GetAppointmentDto> Update(UpdateAppointmentDto model) => throw new NotImplementedException("Appointment updated");

  public async Task<GetAppointmentDto> CancelAppointment(long id)
  {
    var appointment = await ctx.Appointments.SingleOrDefaultAsync(x => x.Id == id);
    appointment.IsCanceled = true;
    await ctx.SaveChangesAsync();

    return new GetAppointmentDto { };
  }
}
