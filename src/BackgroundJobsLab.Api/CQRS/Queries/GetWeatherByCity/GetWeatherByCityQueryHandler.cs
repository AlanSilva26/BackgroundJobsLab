using BackgroundJobsLab.Api.Persistence.EF;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJobsLab.Api.CQRS.Queries.GetWeatherByCity;

public class GetWeatherByCityQueryHandler : IRequestHandler<GetWeatherByCityQuery, Result<IReadOnlyList<WeatherDto>>>
{
    private readonly AppDbContext _context;

    public GetWeatherByCityQueryHandler(AppDbContext context) => _context = context;

    public async Task<Result<IReadOnlyList<WeatherDto>>> Handle(GetWeatherByCityQuery request, CancellationToken cancellationToken)
    {
        var weathers = await _context.WeatherRecords.Where(x => x.City == request.City)
                                                    .OrderByDescending(x => x.CollectedAtUtc)
                                                    .Take(request.Take)
                                                    .Select(weather => new WeatherDto(weather.Id, weather.City, weather.TemperatureC, weather.CollectedAtUtc))
                                                    .ToListAsync(cancellationToken);

        return Result.Ok<IReadOnlyList<WeatherDto>>(weathers);
    }
}
