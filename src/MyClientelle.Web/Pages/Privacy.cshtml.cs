namespace Kampa.MyClientelle.Web.Pages
{
  using Microsoft.AspNetCore.Mvc.RazorPages;

  public class PrivacyModel : PageModel
  {
    private readonly ILogger<PrivacyModel> logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
      this.logger = logger;
    }

    public void OnGet()
    {
    }
  }
}
