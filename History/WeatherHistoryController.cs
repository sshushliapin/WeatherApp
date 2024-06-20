using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WeatherApp.History;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class WeatherHistoryController : ControllerBase
{
    [HttpGet(Name = "GetWeatherHistory")]
    public IEnumerable<WeatherHistoryRecord> Get()
    {
        return [];
    }
}