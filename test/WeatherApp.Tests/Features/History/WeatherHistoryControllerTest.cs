using AutoFixture.Xunit2;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WeatherApp.Features.History;

namespace WeatherApp.Tests.Features.History;

public class WeatherHistoryControllerTest
{
    [Theory, AutoNSubstituteData]
    public async Task PostWithInvalidRequestReturnsBadRequest(
        [Frozen] IMediator mediatr,
        [NoAutoProperties] WeatherHistoryController sut,
        CreateHistoryRecordRequest request,
        string error)
    {
        mediatr.Send(request).Returns(Result.Failure(error));
        var result = await sut.Post(request);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Theory, AutoNSubstituteData]
    public async Task PostWithValidRequestReturnsCreated(
        [NoAutoProperties] WeatherHistoryController sut,
        CreateHistoryRecordRequest request)
    {
        var result = await sut.Post(request);
        Assert.IsType<CreatedResult>(result);
    }
}