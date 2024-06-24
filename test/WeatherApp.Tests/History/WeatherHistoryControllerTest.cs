using AutoFixture.Xunit2;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WeatherApp.History;

namespace WeatherApp.Tests.History;

public class WeatherHistoryControllerTest
{
    [Theory, AutoNSubstituteData]
    public async Task PostWithInvalidRequestReturnsBadRequest(
        [Frozen] IMediator mediatr,
        [NoAutoProperties] WeatherHistoryController sut,
        string error)
    {
        var request = new CreateHistoryRecordRequest();
        mediatr.Send(request).Returns(Result.Failure(error));
        var result = await sut.Post(request);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Theory, AutoNSubstituteData]
    public async Task PostWithValidRequestReturnsCreated(
        [NoAutoProperties] WeatherHistoryController sut)
    {
        var request = new CreateHistoryRecordRequest();
        var result = await sut.Post(request);
        Assert.IsType<CreatedResult>(result);
    }
}