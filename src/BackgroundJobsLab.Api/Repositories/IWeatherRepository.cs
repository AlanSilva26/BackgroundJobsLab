using BackgroundJobsLab.Api.Domain;

namespace BackgroundJobsLab.Api.Repositories;

public interface IWeatherRepository
{
    Task<WeatherRecord?> GetLatestAsync(string city, CancellationToken cancellationToken);
}
