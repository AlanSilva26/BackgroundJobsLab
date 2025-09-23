using BackgroundJobsLab.Api.CQRS.Abstractions;

namespace BackgroundJobsLab.Api.CQRS.Commands.IngestWeather;

public sealed record IngestWeatherCommand(string City, decimal TemperatureC) : ICommand<int>;
