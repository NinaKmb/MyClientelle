namespace Kampa.MyClientelle.Web.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;

using ClientelleAPI.Repositories;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Model;
using Kampa.MyClientelle.Web.Helpers;
using Kampa.MyClientelle.Web.Shared;
using Kampa.MyClientelle.Web.Shared.Dto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/patient")]
[CLSCompliant(false)]
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
  public async Task<ActionResult<GetPatientDto>> Get(long id)
  {
    var patient = await Repository.GetOne(id);
    if (patient == null)
    {
      return NotFound();
    }

    return Ok(patient);
  }

  [HttpPost("")]
  public async Task<ActionResult<GetPatientDto>> Create(CreatePatientDto dto)
  {
    var result = await Repository.Create(dto);
    return Ok(result);
  }

  [HttpPut("")]
  public async Task<ActionResult<GetPatientDto>> Update(UpdatePatientDto dto)
  {
    var result = await Repository.Update(dto);
    if (result == null)
    {
      return NotFound(dto.Id);
    }

    return Ok(result);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(long id)
  {
    await Repository.Delete(id);
    return NoContent();
  }
}
