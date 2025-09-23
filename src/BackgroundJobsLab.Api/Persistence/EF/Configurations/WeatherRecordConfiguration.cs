using BackgroundJobsLab.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackgroundJobsLab.Api.Persistence.EF.Configurations;

public class WeatherRecordConfiguration : IEntityTypeConfiguration<WeatherRecord>
{
    public void Configure(EntityTypeBuilder<WeatherRecord> builder)
    {
        builder.ToTable("WeatherRecord");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.City).HasMaxLength(120).IsRequired();
        builder.Property(x => x.TemperatureC).HasColumnType("decimal(5,2)");
        builder.Property(x => x.CollectedAtUtc).IsRequired();
        builder.HasIndex(x => new { x.City, x.CollectedAtUtc });
    }
}
