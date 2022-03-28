namespace Kampa.MyClientelle.Web.Shared.Repositories;

public interface IAppointmentRepository : IRepository<long, CreateAppointmentDto, GetAppointmentDto, UpdateAppointmentDto>
{
  public Task<GetAppointmentDto> CancelAppointment(long id);
}
