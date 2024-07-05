using Serilog;
using Serilog.Events;

namespace MasterClassProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
                    .WriteTo.File("logs/MasterClassInformationLog.txt", rollingInterval: RollingInterval.Day)
                )
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
                    .WriteTo.File("logs/MasterClassWarningLog.txt", rollingInterval: RollingInterval.Day)
                )
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
                    .WriteTo.File("logs/MasterClassErrorLog.txt", rollingInterval: RollingInterval.Day)
                )
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
                    .WriteTo.File("logs/MasterClassDebugLog.txt", rollingInterval: RollingInterval.Day)
                )
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
                    .WriteTo.File("logs/MasterClassFatalLog.txt", rollingInterval: RollingInterval.Day)
                )
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Verbose)
                    .WriteTo.File("logs/MasterClassVerboseLog.txt", rollingInterval: RollingInterval.Day)
                )
                .CreateLogger();

            try
            {
                Log.Information("Starting host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // Integrating Serilog with the host builder
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}