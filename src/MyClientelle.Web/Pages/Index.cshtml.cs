namespace Kampa.MyClientelle.Web.Pages
{
  using Microsoft.AspNetCore.Mvc.RazorPages;

  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      this.logger = logger;
    }

    public void OnGet()
    {
    }
  }
}