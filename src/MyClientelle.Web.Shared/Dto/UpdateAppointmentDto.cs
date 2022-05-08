namespace Kampa.MyClientelle.Web.Shared;

public class UpdateAppointmentDto
{
  public class Appointment : Entity<long>
  {
    public long Patient { get; set; }

    public DateTimeOffset Date { get; set; }

    public string Remarks { get; set; } = string.Empty;

    public bool IsCanceled { get; set; }
  }
}
