#pragma warning disable SA1516 // Elements should be separated by blank line
using Kampa.MyClientelle.Web.Helpers;

var builder = WebApplication.CreateBuilder(args);
var startup = new WebHostStartup(builder.Configuration, builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app);

await app.RunAsync();
