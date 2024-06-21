using WeatherApp.Database;
using WeatherApp.Features.History;

namespace WeatherApp.Tests.Features.History
{
    public class CreateHistoryRecordTest
    {
        [Theory, AutoNSubstituteData]
        public async Task HandleReturnsValidationErrorIfNoTemperatureSpecified(
            AppDbContext dbContext,
            CreateHistoryRecord.Validator validator)
        {
            var requestWithEmptyTemp = new CreateHistoryRecord.CreateHistoryRecordRequest();
            var sut = new CreateHistoryRecord.Handler(dbContext, validator);
            var result = await sut.Handle(requestWithEmptyTemp, new CancellationToken());
            Assert.True(result.IsFailure);
            Assert.Equal("'Temperature C' must not be empty.", result.Error);
        }
    }
}