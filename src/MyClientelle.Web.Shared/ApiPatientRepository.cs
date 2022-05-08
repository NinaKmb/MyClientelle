namespace Kampa.MyClientelle.Web.Shared;

using System.Collections.Generic;
using System.Threading.Tasks;

using ClientelleAPI.Repositories;

using Kampa.MyClientelle.Web.Shared.Dto;
using Kampa.MyClientelle.Web.Shared.Repositories;

public class ApiPatientRepository : IPatientRepository
{
  public ApiPatientRepository(IMyClientelle api)
  {
    Api = api;
  }

  protected IMyClientelle Api { get; }

  public Task<List<GetPatientDto>> GetAll() => Api.GetAllPatientsAsync();

  public Task<GetPatientDto> GetOne(long id) => Api.GetPatientAsync(id);

  public Task<GetPatientDto> Create(CreatePatientDto patient) => Api.CreatePatientAsync(patient);

  public Task<GetPatientDto> Update(UpdatePatientDto patient) => Api.UpdatePatientAsync(patient);

  public Task Delete(long id) => Api.DeletePatientAsync(id);
}

public class ApiAppointmentRepository : IAppointmentRepository
{
  public ApiAppointmentRepository(IMyClientelle api)
  {
    Api = api;
  }

  protected IMyClientelle Api { get; }

  public Task<GetAppointmentDto> GetAppointment(long id) => Api.GetAppointmentAsync(id);

  public Task<GetAppointmentDto> Create(CreateAppointmentDto appointment);

  public Task<GetAppointmentDto> Update(UpdateAppointmentDto appointment) => Api.UpdateAppointmentAsync(appointment);

  public Task Delete(long id) => Api.DeleteAppointmentAsync(id);
}

public class ApiExaminationsRepository : IExaminationsRepository
{
  public ApiExaminationsRepository(IMyClientelle api)
  {
    Api = api;
  }

  protected IMyClientelle Api { get; }
  
  public Task<GetExaminationsDto> GetExaminations(long exam) => Api.GetAppointmentAsync(exam);

  public Task<GetExaminationsDto> Create(CreateExaminationsDto exam);

  public Task<GetExaminationsDto> Update(UpdateExaminationsDto exam) => Api.UpdateExaminationsAsync(exam);

  public Task Delete(long exam) => Api.DeleteExaminationsAsync(exam);
}
