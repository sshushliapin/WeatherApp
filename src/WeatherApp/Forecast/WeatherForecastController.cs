using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using WeatherApp.Domain.Forecast;
using WeatherApp.Services.Forecast;

namespace WeatherApp.Forecast
{
    public record GetWeatherForecastResponse(DateOnly Date, string Temperature, string Summary);

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class WeatherForecastController(IForecastService forecastService) : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<GetWeatherForecastResponse> Get()
        {
            return forecastService.GetWeatherForecast().Select(ToGetWeatherForecastResponse);
        }

        private GetWeatherForecastResponse ToGetWeatherForecastResponse(WeatherForecast forecast)
        {
            return new GetWeatherForecastResponse(forecast.Date, forecast.Temperature.ToString(), forecast.Summary);
        }
    }
}
