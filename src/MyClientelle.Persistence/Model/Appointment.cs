#nullable disable
namespace Kampa.MyClientelle.Persistence.Model;

using System;

using Kampa.MyClientelle.Persistence.Helpers;

public class Appointment : Entity<long>
{
  public Patient Patient { get; set; }

  public DateTimeOffset Date { get; set; }

  public string Remarks { get; set; } = string.Empty;

  public bool IsCanceled { get; set; }
}
