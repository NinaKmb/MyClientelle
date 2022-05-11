namespace Kampa.MyClientelle.Persistence.Model;

using Kampa.MyClientelle.Persistence.Helpers;

public class Patient : Entity<long>
{
  public string FirstName { get; set; } = string.Empty;

  public string LastName { get; set; } = string.Empty;

  public string Address { get; set; } = string.Empty;

  public string PhoneNumber { get; set; } = string.Empty;

  public string Amka { get; set; } = string.Empty;

  public string Afm { get; set; } = string.Empty;
}
