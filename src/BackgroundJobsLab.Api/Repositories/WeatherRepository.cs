using BackgroundJobsLab.Api.Domain;
using BackgroundJobsLab.Api.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJobsLab.Api.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly AppDbContext _context;

    public WeatherRepository(AppDbContext context) => _context = context;

    public Task<WeatherRecord?> GetLatestAsync(string city, CancellationToken cancellationToken) =>
        _context.WeatherRecords.Where(weather => weather.City == city)
                               .OrderByDescending(weather => weather.CollectedAtUtc)
                               .FirstOrDefaultAsync(cancellationToken);
}
