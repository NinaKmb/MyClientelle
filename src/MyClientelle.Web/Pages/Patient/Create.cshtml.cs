namespace Kampa.MyClientelle.Web.Pages.Patient;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

public class CreateModel : PageModel
{
  private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext context;

  public CreateModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
  {
    this.context = context;
  }

  [BindProperty]
  public Patient Patient { get; set; } = default!;

  public IActionResult OnGet() => Page();

  // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid || context.Patients == null)
    {
      return Page();
    }

    context.Patients.Add(Patient);
    await context.SaveChangesAsync();

    return RedirectToPage("./Index");
  }
}
