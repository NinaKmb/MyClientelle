namespace Kampa.MyClientelle.Web.Helpers;

using Kampa.MyClientelle.Persistence;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[CLSCompliant(false)]
public class BaseController<T> : ControllerBase
  where T : BaseController<T>
{
  public BaseController(MyClientelleDbContext ctx, ILogger<T> logger)
  {
    Ctx = ctx;
    Logger = logger;
  }

  protected MyClientelleDbContext Ctx { get; }

  protected ILogger<T> Logger { get; }
}
