using BackgroundJobsLab.Api.Domain;
using BackgroundJobsLab.Api.Persistence.EF;

namespace BackgroundJobsLab.Tests.Helpers;

public static class DataSeeder
{
    public static async Task SeedWeatherDataAsync(AppDbContext context)
    {
        context.WeatherRecords.AddRange(new[]
        {
            new WeatherRecord { City = "Ariquemes", TemperatureC = 30.2m, CollectedAtUtc = DateTime.UtcNow.AddHours(-1) },
            new WeatherRecord { City = "Ariquemes", TemperatureC = 28.7m, CollectedAtUtc = DateTime.UtcNow },
            new WeatherRecord { City = "Vilhena", TemperatureC = 22.5m, CollectedAtUtc = DateTime.UtcNow }
        });

        await context.SaveChangesAsync();
    }
}
