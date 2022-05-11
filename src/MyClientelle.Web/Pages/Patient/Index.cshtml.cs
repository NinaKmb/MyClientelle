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

  public class IndexModel : PageModel
  {
    private readonly Kampa.MyClientelle.Persistence.MyClientelleDbContext _context;

    public IndexModel(Kampa.MyClientelle.Persistence.MyClientelleDbContext context)
    {
      _context = context;
    }

    public IList<Patient> Patient { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.Patients != null)
      {
        Patient = await _context.Patients.ToListAsync();
      }
    }
  }
}
