namespace Kampa.MyClientelle.Web.Models.Dto;

public class CreateAppointmentDto
{
  public GetPatientDto Patient { get; set; }

  public DateTimeOffset DateTime { get; set; }

  public bool IsCanceled { get; set; }
}
