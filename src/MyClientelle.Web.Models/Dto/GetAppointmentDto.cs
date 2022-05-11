namespace Kampa.MyClientelle.Web.Models.Dto;

public class GetAppointmentDto
{
  public long Id { get; set; }

  public GetPatientDto Patient { get; set; }

  public DateTimeOffset Date { get; set; }

  public string Remarks { get; set; } = string.Empty;

  public bool IsCanceled { get; set; }
}
