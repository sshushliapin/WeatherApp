using WeatherApp.Database;
using WeatherApp.Features.History;

namespace WeatherApp.Tests.Features.History
{
    public class CreateHistoryRecordHandlerTest
    {
        [Theory, AutoNSubstituteData]
        public async Task HandleReturnsValidationErrorIfNoTemperatureSpecified(
            AppDbContext dbContext,
            CreateHistoryRecordValidator validator)
        {
            var requestWithEmptyTemp = new CreateHistoryRecordRequest();
            var sut = new CreateHistoryRecordHandler(dbContext, validator);
            var result = await sut.Handle(requestWithEmptyTemp, new CancellationToken());
            Assert.True(result.IsFailure);
            Assert.Equal("'Temperature C' must not be empty.", result.Error);
        }
    }
}