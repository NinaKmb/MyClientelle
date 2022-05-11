namespace Kampa.MyClientelle.Web.Models.Dto;

public class GetExaminationDto
{
  public long Id { get; set; }

  public string Exam { get; set; }

  public GetAppointmentDto Appointment { get; set; }

  public GetPatientDto Patient { get; set; }
}
