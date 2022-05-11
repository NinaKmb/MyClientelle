using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;

namespace Kampa.MyClientelle.Web.Pages.Patient
{
  using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

  public class CreateModel : PageModel
  {
    private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext _context;

    public CreateModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public Patient Patient { get; set; } = default!;


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.Patients == null || Patient == null)
      {
        return Page();
      }

      _context.Patients.Add(Patient);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
