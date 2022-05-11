namespace Kampa.MyClientelle.Web.Pages.Patient;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

public class IndexModel : PageModel
{
  private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext context;

  public IndexModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
  {
    this.context = context;
  }

#pragma warning disable CA2227 // Collection properties should be read only
  public IList<Patient> Patient { get; set; } = default!;
#pragma warning restore CA2227 // Collection properties should be read only

  public async Task OnGetAsync()
  {
    if (context.Patients != null)
    {
      Patient = await context.Patients.ToListAsync();
    }
  }
}
