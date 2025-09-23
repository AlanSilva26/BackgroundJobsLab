using BackgroundJobsLab.Api.Persistence.EF;
using BackgroundJobsLab.Api.Persistence.Mongo;
using BackgroundJobsLab.Api.Repositories;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace BackgroundJobsLab.Api.DependencyInjections;

public static class DependencyInjectionExtensions
{
    public static void AddServicesDefault(this WebApplicationBuilder builder)
    {
        builder.AddSerilog();
        builder.AddDbContextConfiguration();
        builder.AddMongoSettings();
        builder.AddMediateR();
        builder.AddRepositories();
        builder.AddHangfire();
        builder.AddSwagger();
    }

    private static void AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
                                                       .CreateLogger();

        builder.Host.UseSerilog();
    }

    private static void AddDbContextConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
    }

    private static void AddMongoSettings(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("Mongo"));
        builder.Services.AddSingleton<MongoCollections>();
    }

    private static void AddMediateR(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
    }

    private static void AddHangfire(this WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(configuration =>
            configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                          .UseSimpleAssemblyNameTypeSerializer()
                          .UseRecommendedSerializerSettings()
                          .UseSqlServerStorage(
                              builder.Configuration.GetConnectionString("Hangfire"),
                              new SqlServerStorageOptions
                              {
                                  PrepareSchemaIfNecessary = true,
                                  QueuePollInterval = TimeSpan.FromSeconds(5)
                              }
                          )
        );

        builder.Services.AddHangfireServer();
    }

    private static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
