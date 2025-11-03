using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BackgroundJobsLab.Tests.Helpers;

public static class LoggerHelper
{
    public static ILogger<T> Create<T>()
        => CreateMock<T>().Object;

    public static Mock<ILogger<T>> CreateMock<T>()
    {
        return new Mock<ILogger<T>>();
    }

    public static void VerifyLog<T>(
        this Mock<ILogger<T>> loggerMock,
        LogLevel level,
        string expectedMessage,
        Times? times = null
    )
    {
        times ??= Times.Once();

        loggerMock.Verify(
            expression: logger => logger.Log(
                It.Is<LogLevel>(l => l == level),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((valueObject, type) =>
                    valueObject.ToString()!.CompareTo(expectedMessage) == 0
                ),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times: (Times)times
        );
    }

    public static void VerifyInformation<T>(this Mock<ILogger<T>> loggerMock, string expectedMessage, Times? times = null)
        => loggerMock.VerifyLog(LogLevel.Information, expectedMessage, times);

    public static void VerifyError<T>(this Mock<ILogger<T>> loggerMock, string expectedMessage, Times? times = null)
        => loggerMock.VerifyLog(LogLevel.Error, expectedMessage, times);

    public static void VerifyWarning<T>(this Mock<ILogger<T>> loggerMock, string expectedMessage, Times? times = null)
        => loggerMock.VerifyLog(LogLevel.Warning, expectedMessage, times);

    public static void VerifyInformationCount<T>(this Mock<ILogger<T>> loggerMock, int expectedCount)
        => loggerMock.Invocations.Count(invocation => invocation.Arguments[0].Equals(LogLevel.Information))
                                 .Should()
                                 .Be(expectedCount);
}
