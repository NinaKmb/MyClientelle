namespace Kampa.MyClientelle.Web.Models.Dto;

public class CreateExaminationDto
{
  public string Exam { get; set; }

  public GetAppointmentDto Appointment { get; set; }

  public GetPatientDto Patient { get; set; }
}
