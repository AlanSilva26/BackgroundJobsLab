namespace BackgroundJobsLab.Api.Persistence.Mongo;

public class MongoSettings
{
    public string ConnectionString { get; set; } = default!;

    public string Database { get; set; } = default!;
}
