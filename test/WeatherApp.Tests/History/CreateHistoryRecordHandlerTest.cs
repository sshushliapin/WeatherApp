using WeatherApp.Domain.History;
using WeatherApp.History;

namespace WeatherApp.Tests.History
{
    public class CreateHistoryRecordHandlerTest
    {
        [Theory, AutoNSubstituteData]
        public async Task HandleReturnsValidationErrorIfTemperatureIsOutOfRange(
            IHistoryRepository repository,
            CreateHistoryRecordValidator validator)
        {
            var requestWithEmptyTemp = new CreateHistoryRecordRequest { TemperatureC = int.MinValue };
            var sut = new CreateHistoryRecordHandler(repository, validator);
            var result = await sut.Handle(requestWithEmptyTemp, new CancellationToken());
            Assert.True(result.IsFailure);
            Assert.Contains("'Temperature C' must be between -20 and 50.", result.Error);
        }
    }
}