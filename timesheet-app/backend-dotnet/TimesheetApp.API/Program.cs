using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PronostiekApp.Infrastructure;
using Serilog;
using Serilog.Events;
using TimesheetApp.Application.ErrorHandler;
using TimesheetApp.Domain.Interfaces;
using TimesheetApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging()
    .UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetEmployeesQuery>());

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
    });

// configure DI for application services
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
        .WriteTo.File("logs/TimeSheetInformationLog.log", rollingInterval: RollingInterval.Day)
    )
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
        .WriteTo.File("logs/TimeSheetWarningLog.log", rollingInterval: RollingInterval.Day)
    )
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
        .WriteTo.File("logs/TimeSheetErrorLog.log", rollingInterval: RollingInterval.Day)
    )
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
        .WriteTo.File("logs/TimeSheetDebugLog.log", rollingInterval: RollingInterval.Day)
    )
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
        .WriteTo.File("logs/TimeSheetFatalLog.log", rollingInterval: RollingInterval.Day)
    )
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Verbose)
        .WriteTo.File("logs/TimeSheetVerboseLog.log", rollingInterval: RollingInterval.Day)
    )
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Define the OAuth2.0 scheme that's in use (i.e., Implicit Flow)
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://masterclassdotnetbert.eu.auth0.com/";
    options.Audience = "C8aH6avlfKiTWJ8oSazfSC8ZO5ATtdho";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name"
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();

public partial class Program
{ }