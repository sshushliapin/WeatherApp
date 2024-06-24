using WeatherApp.Domain.Forecast;

namespace WeatherApp.Services.Forecast;

public class ForecastService : IForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public IReadOnlyCollection<WeatherForecast> GetWeatherForecast()
    {
        return Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            new Temperature(Random.Shared.Next(-20, 55)))
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
    }
}