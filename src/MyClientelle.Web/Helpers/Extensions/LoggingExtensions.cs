namespace Kampa.MyClientelle.Web.Helpers.Extensions;

using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.Destructurers;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Exceptions.Refit.Destructurers;
using Serilog.Sinks.SystemConsole.Themes;

public static class LoggingExtensions
{
  public const string IgnoredLogs =
    "SourceContext='Microsoft.Hosting.Lifetime' or SourceContext='Microsoft.EntityFrameworkCore.Database.Command' or SourceContext='Serilog.AspNetCore.RequestLoggingMiddleware'";

  public static LoggerConfiguration ConfigureStartupLogger(this LoggerConfiguration logConfiguration)
    => logConfiguration?
         .MinimumLevel.Verbose()
         .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
         .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
         .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Information)
         .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
         .MinimumLevel.Override("System", LogEventLevel.Error)
         .Enrich.WithMachineName()
         .Enrich.WithEnvironmentUserName()
         .Enrich.WithProcessId()
         .Enrich.WithProcessName()
         .Enrich.WithThreadId()
         .Enrich.WithThreadName()
         .Enrich.FromLogContext()
         .WriteTo.Console(theme: AnsiConsoleTheme.Code, standardErrorFromLevel: LogEventLevel.Verbose)
         .WriteTo.Debug()
       ?? throw new ArgumentNullException(nameof(logConfiguration));

  internal static LoggerConfiguration ConfigureRuntimeLogger(
    this LoggerConfiguration logConfiguration,
    IConfiguration configuration,
    IWebHostEnvironment environment)
    => logConfiguration
      .ConfigureStartupLogger()
      .Enrich.WithProperty("Application", environment.ApplicationName)
      .Enrich.WithProperty("Environment", environment.EnvironmentName)
      .WriteTo.Logger(log => log
        .MinimumLevel.ControlledBy(Program.LevelSwitch)
        .Filter.ByExcluding(IgnoredLogs)
        .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
          .WithDefaultDestructurers()
          .WithDestructurers(new IExceptionDestructurer[]
          {
            new ApiExceptionDestructurer(destructureCommonExceptionProperties: false),
            new DbUpdateExceptionDestructurer(),
            new Serilog.Exceptions.MsSqlServer.Destructurers.SqlExceptionDestructurer(),
          })
          .WithRootName("Exception"))
        .WriteTo.File(
          configuration.GetValue("AzureDeployment", false)
            ? $@"D:\home\LogFiles\Application\{environment.ApplicationName}.txt"
            : Path.Combine(Directory.GetCurrentDirectory(), "Logs", $"{environment.ApplicationName}-.log"),
          fileSizeLimitBytes: 31_457_280,
          rollingInterval: RollingInterval.Day,
          rollOnFileSizeLimit: true,
          retainedFileCountLimit: 10,
          shared: true,
          flushToDiskInterval: TimeSpan.FromSeconds(1))
        .WriteTo.Seq(
          configuration["Serilog:Seq:Uri"],
          apiKey: configuration["Serilog:Seq:ApiKey"],
          controlLevelSwitch: Program.LevelSwitch));
}
