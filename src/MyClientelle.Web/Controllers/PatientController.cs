namespace Kampa.MyClientelle.Web.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;

using Kampa.MyClientelle.Web.Helpers;
using Kampa.MyClientelle.Web.Models.Dto;
using Kampa.MyClientelle.Web.Models.Repositories;

using Microsoft.AspNetCore.Mvc;

[Route("api/patient")]
public class PatientController : BaseController<PatientController>, ICrudController<IPatientRepository, long, GetPatientDto, CreatePatientDto, UpdatePatientDto>
{
  public PatientController(IPatientRepository repository, ILogger<PatientController> logger)
  : base(logger)
  {
    Repository = repository;
  }

  public IPatientRepository Repository { get; init; }

  [HttpGet("")]
  public async Task<ActionResult<List<GetPatientDto>>> GetAll()
  {
    var result = await Repository.GetAll();
    return Ok(result);
  }

  /// <summary>
  /// Fetches patient with the selected id.
  /// </summary>
  /// <param name="id">Id of the patient to return.</param>
  /// <returns><see cref="GetPatientDto"/> describing current patient.</returns>
  [HttpGet("{id}")]
  public async Task<ActionResult<GetPatientDto>> GetOne(long id)
  {
    var patient = await Repository.GetOne(id);
    return patient != null
      ? Ok(patient)
      : NotFound();
  }

  [HttpPost("")]
  public async Task<ActionResult<GetPatientDto>> Create(CreatePatientDto dto)
  {
    var result = await Repository.Create(dto);
    return Ok(result);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<GetPatientDto>> Update(long id, UpdatePatientDto dto)
  {
    var result = await Repository.Update(id, dto);
    return result != null
      ? Ok(result)
      : NotFound(id);
  }

  /// <summary>
  /// Deletes a patient with the given id.
  /// </summary>
  /// <param name="id">The id of the patient to delete.</param>
  /// <returns>Nothing.</returns>
  /// <response code="204">Item deleted successfully.</response>
  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(long id)
  {
    await Repository.Delete(id);
    return NoContent();
  }
}
