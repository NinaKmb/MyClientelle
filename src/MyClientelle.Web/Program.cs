#pragma warning disable SA1516 // Elements should be separated by blank line
using ClientelleAPI.Repositories;

using Kampa.MyClientelle.Persistence;
using Kampa.MyClientelle.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyClientelleDbContext>(o => o.UseSqlite("Data source=patients.db"));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

// AN o xrhsths exei dialexei ccloud version
// builder.Services.AddScoped<IPatientRepository, ApiPatientRepository>();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientAPI", Version = "v1" });
  c.EnableAnnotations(true, true);
  c.DescribeAllParametersInCamelCase();
  c.OperationFilter<SecurityRequirementsOperationFilter>();
  c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
  c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
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

app.UseHttpsRedirection();

app.UseRouting();
app.UseReDoc(c =>
{
  c.SpecUrl("/swagger/v1/swagger.json");
  c.ExpandResponses("none");
  c.RequiredPropsFirst();
  c.SortPropsAlphabetically();
  c.HideDownloadButton();
  c.HideHostname();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
