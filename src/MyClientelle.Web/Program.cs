#pragma warning disable CA1031 // Do not catch general exception types : Final frontier, only there to quit gracefully
namespace Kampa.MyClientelle.Web;

using Kampa.MyClientelle.Web.Helpers;
using Kampa.MyClientelle.Web.Helpers.Extensions;

using Microsoft.Extensions.Logging.Abstractions;

using Serilog;
using Serilog.Core;
using Serilog.Extensions.Logging;

public static class Program
{
  internal static readonly LoggingLevelSwitch LevelSwitch = new();
  private static Microsoft.Extensions.Logging.ILogger logger = new NullLogger<WebHostStartup>();

  public static async Task<int> Main(string[] args)
  {
    Log.Logger = new LoggerConfiguration()
      .ConfigureStartupLogger()
      .CreateBootstrapLogger();
    using var loggerProvider = new SerilogLoggerProvider(Log.Logger);
    logger = loggerProvider.CreateLogger(nameof(WebHostStartup));

    try
    {
      await using var app = CreateApplication(args);

      await app.RunAsync();
      return 0;
    }
    catch (Exception ex)
    {
      logger.LogCritical(LogTemplates.UnhandledException, ex.Message);
    }
    finally
    {
      Log.CloseAndFlush();
    }

    return 1;
  }

  private static WebApplication CreateApplication(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Host
      .UseSerilog((_, services, loggerConfiguration) => loggerConfiguration
        .ConfigureRuntimeLogger(builder.Configuration, builder.Environment));

    var startup = new WebHostStartup(builder.Configuration, builder.Environment);
    startup.ConfigureServices(builder.Services);

    var app = builder.Build();
    startup.Configure(app);

    return app;
  }
}
