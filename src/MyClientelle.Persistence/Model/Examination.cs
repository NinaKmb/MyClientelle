#nullable disable
namespace Kampa.MyClientelle.Persistence.Model;

using Kampa.MyClientelle.Persistence.Helpers;

public class Examination : Entity<long>
{
  public string Exam { get; set; } = string.Empty;

  public Appointment Appointment { get; set; }

  public Patient Patient { get; set; }
}
