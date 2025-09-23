namespace BackgroundJobsLab.Api.Domain;

public class WeatherRecord
{
    public int Id { get; set; }

    public string City { get; set; } = default!;

    public decimal TemperatureC { get; set; }

    public DateTime CollectedAtUtc { get; set; }
}
