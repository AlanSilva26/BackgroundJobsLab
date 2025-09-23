using BackgroundJobsLab.Api.DependencyInjections;
using BackgroundJobsLab.Api.Jobs;
using Hangfire;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServicesDefault();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseSerilogRequestLogging("/hangfire");

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "BackgroundJobsLab Dashboard",
    StatsPollingInterval = 2000
});

var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();
recurringJobManager.AddOrUpdate<IngestWeatherJob>(
    "ingest-weather",
    job => job.RunAsync(),
    Cron.Minutely,
    new RecurringJobOptions()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "BackgroundJobsLab OK. Acesse /swagger e /hangfire");

app.Run();
