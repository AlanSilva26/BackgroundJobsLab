using BackgroundJobsLab.Api.CQRS.Commands.IngestWeather;
using BackgroundJobsLab.Api.CQRS.Queries.GetWeatherByCity;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundJobsLab.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Ingest([FromBody] IngestWeatherCommand command)
    {
        Result<int> result = await _mediator.Send(command);

        return result.IsSuccess ? Ok(new { id = result.Value }) : Problem("Falha ao registrar o clima");
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> Get(string city, [FromQuery] int take = 20)
    {
        var result = await _mediator.Send(new GetWeatherByCityQuery(city, take));

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
}
