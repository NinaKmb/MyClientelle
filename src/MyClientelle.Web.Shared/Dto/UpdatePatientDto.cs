namespace Kampa.MyClientelle.Web.Shared.Dto;

public class UpdatePatientDto
{
  public long Id { get; set; }

  public string FirstName { get; set; }

  public string LastName { get; set; }

  public string Address { get; set; }

  public string PhoneNumber { get; }
}
