using BackgroundJobsLab.Api.CQRS.Abstractions;

namespace BackgroundJobsLab.Api.CQRS.Queries.GetWeatherByCity;

public sealed record GetWeatherByCityQuery(string City, int Take = 20) : IQuery<IReadOnlyList<WeatherDto>>;

public sealed record WeatherDto(int Id, string City, decimal TemperatureC, DateTime CollectedAtUtc);
