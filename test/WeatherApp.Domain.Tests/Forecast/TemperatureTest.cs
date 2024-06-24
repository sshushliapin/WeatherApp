using FluentAssertions;
using WeatherApp.Domain.Forecast;

namespace WeatherApp.Domain.Tests.Forecast;

public class TemperatureTest
{
    [Theory]
    [InlineData(-10, "-10 C")]
    [InlineData(20, "20 C")]
    public void ToStringPrintsTemperatureInCelsius(int initial, string expected)
    {
        var sut = new Temperature(initial);
        sut.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData(-10, "15 F")]
    [InlineData(20, "67 F")]
    public void ToFahrenheitConvertsTemperature(int initial, string expected)
    {
        var sut = new Temperature(initial);
        sut.ToFahrenheit().Should().Be(expected);
    }
}