using BackgroundJobsLab.Api.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJobsLab.Tests.Helpers;

public static class DbContextHelper
{
    public static AppDbContext CreateInMemoryContext(string? dbName = null)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: dbName ?? Guid.NewGuid().ToString())
                                                                 .EnableSensitiveDataLogging().Options;

        var context = new AppDbContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    public static void ResetDatabase(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}
