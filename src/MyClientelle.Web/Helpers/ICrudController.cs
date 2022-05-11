namespace Kampa.MyClientelle.Web.Helpers;

using Microsoft.AspNetCore.Mvc;

public interface ICrudController<out TRepository, in TKey, TGetDto, in TCreateDto, in TUpdateDto>
  where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
  public TRepository Repository { get; }

  public Task<ActionResult<List<TGetDto>>> GetAll();

  public Task<ActionResult<TGetDto>> GetOne(TKey id);

  public Task<ActionResult<TGetDto>> Create(TCreateDto dto);

  public Task<ActionResult<TGetDto>> Update(TKey id, TUpdateDto dto);

  public Task<ActionResult> Delete(TKey id);
}
