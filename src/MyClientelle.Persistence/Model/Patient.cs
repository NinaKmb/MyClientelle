namespace Kampa.MyClientelle.Persistence.Model;

using Kampa.MyClientelle.Persistence.Helpers;

public class Patient : Entity<long>
{
  public string FirstName { get; set; } = string.Empty;

  public string LastName { get; set; } = string.Empty;

  public string Address { get; set; } = string.Empty;

  public string PhoneNumber { get; set; } = string.Empty;

  public string AMKA { get; set; } = string.Empty;

  public string AFM { get; set; } = string.Empty;
}
