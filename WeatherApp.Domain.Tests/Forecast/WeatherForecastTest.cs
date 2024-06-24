using AutoFixture.Xunit2;
using FluentAssertions;
using WeatherApp.Domain.Forecast;

namespace WeatherApp.Domain.Tests.Forecast
{
    public class WeatherForecastTest
    {
        [Theory, AutoData]
        public void NewWeatherForecastWithPastDateThrows(Temperature temperature)
        {
            var pastDate = DateOnly.FromDateTime(DateTime.Today).AddDays(-1);
            var action = () => new WeatherForecast(pastDate, temperature);
            action.Should().Throw<ArgumentException>().WithMessage("Date cannot be past.");
        }

        [Theory, AutoData]
        public void NewWeatherForecastSetsDate(Temperature temperature)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var sut = new WeatherForecast(today, temperature);
            sut.Date.Should().Be(today);
        }
    }
}
