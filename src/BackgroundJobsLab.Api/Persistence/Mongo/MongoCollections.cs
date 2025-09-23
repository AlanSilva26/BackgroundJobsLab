using BackgroundJobsLab.Api.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BackgroundJobsLab.Api.Persistence.Mongo;

public class MongoCollections
{
    public MongoCollections(IOptions<MongoSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        Database = client.GetDatabase(options.Value.Database);
    }

    public IMongoDatabase Database { get; }

    public IMongoCollection<IngestionLog> IngestionLogs => Database.GetCollection<IngestionLog>("ingestion_logs");
}

public class IngestionLog
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string City { get; set; } = default!;

    public decimal TemperatureC { get; set; }

    public DateTime LoggedAtUtc { get; set; } = DateTime.UtcNow;

    public static implicit operator IngestionLog(WeatherRecord weatherRecord)
    {
        return new IngestionLog
        {
            City = weatherRecord.City,
            TemperatureC = weatherRecord.TemperatureC
        };
    }
}
