namespace Kampa.MyClientelle.Web.Helpers;

using Kampa.MyClientelle.Persistence;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;

public class WebHostStartup
{
  private readonly IConfiguration configuration;
  private readonly IWebHostEnvironment environment;

  public WebHostStartup(IConfiguration configuration, IWebHostEnvironment environment)
  {
    this.configuration = configuration;
    this.environment = environment;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    ArgumentNullException.ThrowIfNull(services);
    services.AddRazorPages();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientAPI", Version = "v1" });
      c.EnableAnnotations(true, true);
      c.DescribeAllParametersInCamelCase();
      c.OperationFilter<SecurityRequirementsOperationFilter>();
      c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
      c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml"));
    });

    services.AddDbContext<MyClientelleDbContext>(o =>
      o.UseSqlServer(configuration.GetConnectionString("MyClientelleDb")));

    services.AddAuthorization();
    services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      })
      .AddCookie(cookie =>
      {
        cookie.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        cookie.SlidingExpiration = true;
      })
      .AddOpenIdConnect(openId =>
      {
        openId.ClientId = configuration["Authentication:OpenId:ClientId"];
        openId.ClientSecret = configuration["Authentication:OpenId:ClientSecret"];
        openId.MetadataAddress = $"{configuration["Authentication:OpenId:Authority"]}/.well-known/openid-configuration";

        openId.Scope.Add("profile");
        openId.Scope.Add("openid");
      });
  }

  public void Configure(WebApplication app)
  {
    ArgumentNullException.ThrowIfNull(app);

    app.UseSwagger();
    if (environment.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientAPI v1");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.EnableDeepLinking();
        c.EnableFilter();
        c.EnableValidator();
        c.DisplayOperationId();
        c.DisplayRequestDuration();
        c.ShowExtensions();
        c.ShowCommonExtensions();
      });
    }
    else
    {
      app.UseExceptionHandler("/Error");
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseReDoc(c =>
    {
      c.SpecUrl("/swagger/v1/swagger.json");
      c.ExpandResponses("none");
      c.RequiredPropsFirst();
      c.SortPropsAlphabetically();
      c.HideDownloadButton();
      c.HideHostname();
    });

    app.UseEndpoints(endpoint =>
    {
      endpoint.MapControllers();
      endpoint.MapRazorPages();
    });
  }
}
