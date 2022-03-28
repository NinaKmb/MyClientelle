namespace Kampa.MyClientelle.Web.Shared;

using Kampa.MyClientelle.Web.Shared.Dto;

public class CreateAppointmentDto
{
  public GetPatientDto Patient { get; set; }

  public DateTimeOffset DateTime { get; set; }

  public bool IsCanceled { get; set; }
}
