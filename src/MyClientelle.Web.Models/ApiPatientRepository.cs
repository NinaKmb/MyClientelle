namespace Kampa.MyClientelle.Web.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

using Kampa.MyClientelle.Web.Models.Dto;
using Kampa.MyClientelle.Web.Models.Repositories;

public class ApiPatientRepository : IPatientRepository
{
  public ApiPatientRepository(IMyClientelle api)
  {
    Api = api;
  }

  protected IMyClientelle Api { get; }

  public Task<List<GetPatientDto>> GetAll() => Api.GetAllPatientsAsync();

  public Task<GetPatientDto> GetOne(long id) => Api.GetPatientAsync(id);

  public Task<GetPatientDto> Create(CreatePatientDto model) => Api.CreatePatientAsync(model);

  public Task<GetPatientDto> Update(long id, UpdatePatientDto model) => Api.UpdatePatientAsync(id, model);

  public Task Delete(long id) => Api.DeletePatientAsync(id);
}

public class ApiAppointmentRepository : IAppointmentRepository
{
  public ApiAppointmentRepository(IMyClientelle api)
  {
    Api = api;
  }

  protected IMyClientelle Api { get; }

  /// <inheritdoc />
  public Task<GetAppointmentDto> Create(CreateAppointmentDto model) => Api.CreateAppointmentAsync(model);

  /// <inheritdoc />
  public Task<GetAppointmentDto> GetOne(long id) => Api.GetAppointmentAsync(id);

  /// <inheritdoc />
  public Task<List<GetAppointmentDto>> GetAll() => Api.GetAllAppointmentsAsync();

  /// <inheritdoc />
  public Task<GetAppointmentDto> Update(long id, UpdateAppointmentDto model) => Api.UpdateAppointmentAsync(id, model);

  /// <inheritdoc />
  public Task Delete(long id) => Api.DeleteAppointmentAsync(id);

  /// <inheritdoc />
  public Task<GetAppointmentDto> CancelAppointment(long id) => Api.CancelAppointmentAsync(id);
}

public class ApiExaminationsRepository : IExaminationRepository
{
  public ApiExaminationsRepository(IMyClientelle api)
  {
    Api = api;
  }

  protected IMyClientelle Api { get; }

  public Task<GetExaminationDto> Create(CreateExaminationDto model) => Api.CreateExaminationsAsync(model);

  public Task<GetExaminationDto> GetOne(long id) => Api.GetExaminationsAsync(id);

  public Task<List<GetExaminationDto>> GetAll() => Api.GetAllExaminationsAsync();

  public Task<GetExaminationDto> Update(long id, UpdateExaminationDto model) => Api.UpdateExaminationsAsync(id, model);

  public Task Delete(long id) => Api.DeleteExaminationsAsync(id);
}
