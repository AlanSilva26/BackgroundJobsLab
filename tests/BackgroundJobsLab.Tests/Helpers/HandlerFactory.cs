using BackgroundJobsLab.Api.CQRS.Commands.IngestWeather;
using BackgroundJobsLab.Api.Persistence.EF;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace BackgroundJobsLab.Tests.Helpers;

public static class HandlerFactory
{
    public static IngestWeatherCommandHandler CreateIngestWeatherHandler(
        AppDbContext? context = null,
        ILogger<IngestWeatherCommandHandler>? handlerLogger = null
    )
    {
        var dbContext = context ?? DbContextHelper.CreateInMemoryContext();

        var mongo = MongoHelper.CreateFake();

        var logger = handlerLogger ?? LoggerHelper.Create<IngestWeatherCommandHandler>();

        return new IngestWeatherCommandHandler(dbContext, mongo, logger);
    }
}
