namespace Kampa.MyClientelle.Web.Models.Dto;

public class CreatePatientDto
{
  public string FirstName { get; set; }

  public string LastName { get; set; }

  public string Address { get; set; }

  public string PhoneNumber { get; }

  public string AFM { get; }

  public string AMKA { get; }
}
