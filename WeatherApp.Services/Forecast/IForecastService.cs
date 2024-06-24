using WeatherApp.Domain.Forecast;

namespace WeatherApp.Services.Forecast
{
    public interface IForecastService
    {
        IReadOnlyCollection<WeatherForecast> GetWeatherForecast();
    }
}