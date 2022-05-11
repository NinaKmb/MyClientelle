namespace Kampa.MyClientelle.Web.Helpers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class BaseController<T> : ControllerBase
  where T : BaseController<T>
{
  public BaseController(ILogger<T> logger)
  {
    Logger = logger;
  }

  protected ILogger<T> Logger { get; }
}
