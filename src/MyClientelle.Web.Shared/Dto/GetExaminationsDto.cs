namespace Kampa.MyClientelle.Web.Shared.Dto;

public class GetExaminationsDto
{
  public class Examinations : Entity<long>
  {
    public string Exam { get; set; } = string.Empty;
  }
}
