namespace Kampa.MyClientelle.Web.Shared;

using Kampa.MyClientelle.Web.Shared.Dto;

using Refit;

public interface IMyClientelle
{
  [Get("/api/patient/{id}")]
  Task<GetPatientDto> GetPatientAsync(long id);

  [Get("/api/patient")]
  Task<List<GetPatientDto>> GetAllPatientsAsync();

  [Post("/api/patient")]
  Task<GetPatientDto> CreatePatientAsync(CreatePatientDto dto);

  [Put("/api/patient")]
  Task<GetPatientDto> UpdatePatientAsync(UpdatePatientDto dto);

  [Delete("/api/patient/{id}")]
  Task DeletePatientAsync(long id);
}

public interface IMyClientelle
{
  [Get("/api/appointment")]
  Task<GetAppointmentDto> GetAppointmentAsync(long id);

  [Get("/api/Appointment")]
  Task<List<GetAppointmentDto>> GetAllAppointmentAsync();

  [Post("/api/Appointment")]
  Task<GetPatientDto> CreateAppointmentAsync(CreateAppointmentDto dto);

  [Put("/api/Appointment")]
  Task<GetAppointmentDto> UpdateAppointmentAsync(UpdateAppointmentDto dto);

  [Delete("/api/Appointment")]
  Task DeleteAppointmentAsync(long id);
}
