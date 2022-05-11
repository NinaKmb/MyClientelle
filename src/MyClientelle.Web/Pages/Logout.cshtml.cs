namespace Kampa.MyClientelle.Web.Pages;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize]
public class LogoutModel : PageModel
{
  public ActionResult OnGet()
  {
    var result =
      new SignOutResult(new[]
      {
        OpenIdConnectDefaults.AuthenticationScheme, CookieAuthenticationDefaults.AuthenticationScheme,
      })
      {
        Properties = new AuthenticationProperties()
        {
          RedirectUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/",
        },
      };

    return result;
  }
}
