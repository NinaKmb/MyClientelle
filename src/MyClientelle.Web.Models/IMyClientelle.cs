namespace Kampa.MyClientelle.Web.Models;

using Kampa.MyClientelle.Web.Models.Dto;

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
  Task<GetPatientDto> UpdatePatientAsync(long id, UpdatePatientDto dto);

  [Delete("/api/patient/{id}")]
  Task DeletePatientAsync(long id);

  [Get("/api/appointment/{id}")]
  Task<GetAppointmentDto> GetAppointmentAsync(long id);

  [Get("/api/appointment")]
  Task<List<GetAppointmentDto>> GetAllAppointmentsAsync();

  [Post("/api/appointment")]
  Task<GetAppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto);

  [Put("/api/appointment/{id}")]
  Task<GetAppointmentDto> UpdateAppointmentAsync(long id, UpdateAppointmentDto dto);

  [Delete("/api/appointment/{id}")]
  Task DeleteAppointmentAsync(long id);

  [Post("/api/appointment/{id}/cancel")]
  Task<GetAppointmentDto> CancelAppointmentAsync(long id);

  [Get("/api/Examinations/{id}")]
  Task<GetExaminationDto> GetExaminationsAsync(long id);

  [Get("/api/Examinations")]
  Task<List<GetExaminationDto>> GetAllExaminationsAsync();

  [Post("/api/Examinations")]
  Task<GetExaminationDto> CreateExaminationsAsync(CreateExaminationDto dto);

  [Put("/api/Examinations")]
  Task<GetExaminationDto> UpdateExaminationsAsync(long id, UpdateExaminationDto dto);

  [Delete("/api/Examinations/{id}")]
  Task DeleteExaminationsAsync(long id);
}
