using BackgroundJobsLab.Api.CQRS.Commands.IngestWeather;
using MediatR;

namespace BackgroundJobsLab.Api.Jobs;

public class IngestWeatherJob
{
    private readonly IMediator _mediator;
    private readonly ILogger<IngestWeatherJob> _logger;
    private static readonly string[] Cities = ["Ariquemes", "Porto Velho", "Vilhena", "Ji-Paraná"];

    public IngestWeatherJob(IMediator mediator, ILogger<IngestWeatherJob> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public async Task RunAsync()
    {
        var random = new Random();
        var city = Cities[random.Next(Cities.Length)];
        var temperature = (decimal)(random.NextDouble() * 25 + 15);

        var result = await _mediator.Send(new IngestWeatherCommand(city, Math.Round(temperature, 2)));

        if (result.IsSuccess)
            _logger.LogInformation("Sucesso: registro meteorológico criado - #{Id}", result.Value);
        else
            _logger.LogWarning("Falha: {Errors}", string.Join(",", result.Errors.Select(error => error.Message)));
    }
}
