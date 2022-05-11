namespace Kampa.MyClientelle.Web.Pages.Patient;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

public class EditModel : PageModel
{
  private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext context;

  public EditModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
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

    Patient = patient;
    return Page();
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid)
    {
      return Page();
    }

    context.Attach(Patient).State = EntityState.Modified;

    try
    {
      await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!PatientExists(Patient.Id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return RedirectToPage("./Index");
  }

  private bool PatientExists(long id) => (context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
}
