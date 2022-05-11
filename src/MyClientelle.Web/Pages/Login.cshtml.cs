namespace Kampa.MyClientelle.Web.Pages;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
  public ActionResult OnGet() =>
    !HttpContext.User.Identity?.IsAuthenticated ?? false
      ? Challenge(OpenIdConnectDefaults.AuthenticationScheme)
      : Redirect($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/");
}
