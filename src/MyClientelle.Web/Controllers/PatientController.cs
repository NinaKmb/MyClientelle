namespace Kampa.MyClientelle.Web.Controllers;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Web.Helpers;
using Kampa.MyClientelle.Web.Shared;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/patient")]
[CLSCompliant(false)]
public class PatientController : BaseController<PatientController>
{
  public PatientController(MyClientelleDbContext ctx, ILogger<PatientController> logger)
    : base(ctx, logger)
  {
  }

  /// <summary>
  /// Fetches patient with the selected id.
  /// </summary>
  /// <param name="id">Id of the patient to return.</param>
  /// <returns><see cref="GetPatientDto"/> describing current patient.</returns>
  [HttpGet("")]
  public async Task<ActionResult<GetPatientDto>> GetPatient(long id)
  {
    var patient = await Ctx.Patients
      .Where(x => x.Id == id)
      .FirstOrDefaultAsync();

    if (patient == null)
    {
      return NotFound();
    }

    return new GetPatientDto(patient.Id, patient.FirstName);
  }
}
