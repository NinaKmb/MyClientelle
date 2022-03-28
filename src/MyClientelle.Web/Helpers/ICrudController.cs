namespace Kampa.MyClientelle.Web.Helpers;

using Microsoft.AspNetCore.Mvc;

[CLSCompliant(false)]
public interface ICrudController<TRepository, TKey, TGetDto, TCreateDto, TUpdateDto>
  where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
  public TRepository Repository { get; }

  public Task<ActionResult<List<TGetDto>>> GetAll();

  public Task<ActionResult<TGetDto>> Get(TKey id);

  public Task<ActionResult<TGetDto>> Create(TCreateDto dto);

  public Task<ActionResult<TGetDto>> Update(TUpdateDto dto);

  public Task<ActionResult> Delete(TKey id);
}
