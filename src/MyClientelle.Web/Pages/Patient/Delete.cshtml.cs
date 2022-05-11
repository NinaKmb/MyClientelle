using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;

namespace Kampa.MyClientelle.Web.Pages.Patient
{
  using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

  public class DeleteModel : PageModel
  {
    private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext _context;

    public DeleteModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Patient Patient { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(long? id)
    {
      if (id == null || _context.Patients == null)
      {
        return NotFound();
      }

      var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

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
      if (id == null || _context.Patients == null)
      {
        return NotFound();
      }

      var patient = await _context.Patients.FindAsync(id);

      if (patient != null)
      {
        Patient = patient;
        _context.Patients.Remove(Patient);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
