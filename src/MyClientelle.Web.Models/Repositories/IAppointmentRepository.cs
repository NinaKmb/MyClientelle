namespace Kampa.MyClientelle.Web.Models.Repositories;

using Kampa.MyClientelle.Web.Models.Dto;

public interface IAppointmentRepository : IRepository<long, CreateAppointmentDto, GetAppointmentDto, UpdateAppointmentDto>
{
  public Task<GetAppointmentDto> CancelAppointment(long id);
}
