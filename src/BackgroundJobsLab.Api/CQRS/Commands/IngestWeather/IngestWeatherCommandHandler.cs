using BackgroundJobsLab.Api.Domain;
using BackgroundJobsLab.Api.Persistence.EF;
using BackgroundJobsLab.Api.Persistence.Mongo;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace BackgroundJobsLab.Api.CQRS.Commands.IngestWeather;

public class IngestWeatherCommandHandler : IRequestHandler<IngestWeatherCommand, Result<int>>
{
    private readonly AppDbContext _context;
    private readonly MongoCollections _mongo;
    private readonly ILogger<IngestWeatherCommandHandler> _logger;

    public IngestWeatherCommandHandler(AppDbContext context, MongoCollections mongo, ILogger<IngestWeatherCommandHandler> logger)
    {
        _context = context;
        _mongo = mongo;
        _logger = logger;
    }

    public async Task<Result<int>> Handle(IngestWeatherCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var weatherRecord = new WeatherRecord
            {
                City = request.City,
                TemperatureC = request.TemperatureC,
                CollectedAtUtc = DateTime.UtcNow,
            };

            _context.WeatherRecords.Add(weatherRecord);
            await _context.SaveChangesAsync();

            IngestionLog ingestionLog = weatherRecord;

            await _mongo.IngestionLogs.InsertOneAsync(ingestionLog, new InsertOneOptions(), cancellationToken);

            _logger.LogInformation(
                "Clima registrado para {City} com a temperatura em {Temperature}ºC (Id: {Id})",
                weatherRecord.City,
                weatherRecord.TemperatureC,
                weatherRecord.Id
            );

            return Result.Ok(weatherRecord.Id);
        }
        catch (DbUpdateException exception)
        {
            _logger.LogError(exception, "Erro ao salvar o clima");

            return Result.Fail<int>("DATABASE_ERROR");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Erro inesperado");

            return Result.Fail<int>("UNEXPECTED_ERROR");
        }
    }
}
