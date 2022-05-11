using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;

namespace Kampa.MyClientelle.Web.Pages.Patient
{
  using Patient = Kampa.MyClientelle.Persistence.Model.Patient;

  public class EditModel : PageModel
  {
    private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext _context;

    public EditModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
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

      Patient = patient;
      return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Patient).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
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

    private bool PatientExists(long id)
    {
      return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
