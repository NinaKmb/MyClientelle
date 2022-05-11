namespace Kampa.MyClientelle.Web.Pages.Patient;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

public class DeleteModel : PageModel
{
  private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext context;

  public DeleteModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
  {
    this.context = context;
  }

  [BindProperty]
  public Patient Patient { get; set; } = default!;

  public async Task<IActionResult> OnGetAsync(long? id)
  {
    if (id == null || context.Patients == null)
    {
      return NotFound();
    }

    var patient = await context.Patients.FirstOrDefaultAsync(m => m.Id == id);

    if (patient == null)
    {
      return NotFound();
    }
    else
    {
      Patient = patient;
    }

    return Page();
  }

  public async Task<IActionResult> OnPostAsync(long? id)
  {
    if (id == null || context.Patients == null)
    {
      return NotFound();
    }

    var patient = await context.Patients.FindAsync(id);

    if (patient != null)
    {
      Patient = patient;
      context.Patients.Remove(Patient);
      await context.SaveChangesAsync();
    }

    return RedirectToPage("./Index");
  }
}
