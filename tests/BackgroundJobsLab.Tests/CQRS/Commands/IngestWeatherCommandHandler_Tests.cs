using BackgroundJobsLab.Api.CQRS.Commands.IngestWeather;
using BackgroundJobsLab.Tests.Helpers;
using FluentAssertions;
using Moq;

namespace BackgroundJobsLab.Tests.CQRS.Commands;

public class IngestWeatherCommandHandler_Tests
{
    [Fact(DisplayName = "Deve registrar um novo clima com sucesso no banco e logar no Mongo")]
    public async Task Deve_Registrar_Clima_Com_Sucesso()
    {
        // Arrange
        var context = DbContextHelper.CreateInMemoryContext();
        var loggerMock = LoggerHelper.CreateMock<IngestWeatherCommandHandler>();
        var handler = HandlerFactory.CreateIngestWeatherHandler(context, loggerMock.Object);
        var command = new IngestWeatherCommand(City: "Ariquemes", TemperatureC: 28.7m);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue(because: "O resultado deve ser bem sucedido");
        result.Value.Should().BeGreaterThan(expected: 0, because: "O ID retornado deve ser válido");

        var entity = await context.WeatherRecords.FindAsync(result.Value);
        entity.Should().NotBeNull(because: "O registro deve existir no banco");
        entity!.City.Should().Be(expected: "Ariquemes");
        entity.TemperatureC.Should().Be(expected: 28.7m);
        entity.CollectedAtUtc.Should().BeCloseTo(nearbyTime: DateTime.UtcNow, precision: TimeSpan.FromSeconds(2));

        loggerMock.VerifyInformation(
            expectedMessage: "Clima registrado para Ariquemes com a temperatura em 28.7ºC (Id: 1)",
            times: Times.Once()
        );
    }

    [Fact(DisplayName = "Deve falhar ao tentar salvar quando o banco lança exceção")]
    public async Task Deve_Falhar_Quando_Houver_Erro_No_Banco()
    {
        // Arrange
        var brokenContext = DbContextHelper.CreateInMemoryContext();
        brokenContext.Dispose();

        var loggerMock = LoggerHelper.CreateMock<IngestWeatherCommandHandler>();

        var handler = HandlerFactory.CreateIngestWeatherHandler(brokenContext, loggerMock.Object);

        var command = new IngestWeatherCommand(City: "Vilhena", TemperatureC: 30.5m);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.First().Message.Should().BeOneOf(validValues: ["DATABASE_ERROR", "UNEXPECTED_ERROR"]);

        loggerMock.VerifyError(
            expectedMessage: "Erro inesperado",
            times: Times.Once()
        );
    }
}
