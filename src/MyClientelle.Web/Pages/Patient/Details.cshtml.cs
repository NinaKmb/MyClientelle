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

  public class DetailsModel : PageModel
  {
    private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext _context;

    public DetailsModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
    {
      _context = context;
    }

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
  }
}
