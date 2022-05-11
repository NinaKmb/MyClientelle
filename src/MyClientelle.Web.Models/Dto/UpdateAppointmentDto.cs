namespace Kampa.MyClientelle.Web.Models.Dto;

public class UpdateAppointmentDto
{
  public long Patient { get; set; }

  public DateTimeOffset Date { get; set; }

  public string Remarks { get; set; } = string.Empty;

  public bool IsCanceled { get; set; }
}
