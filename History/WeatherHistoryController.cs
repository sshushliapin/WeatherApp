using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WeatherApp.History;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class WeatherHistoryController(WeatherHistoryDbContext dbContext) : ControllerBase
{
    [HttpGet(Name = "GetWeatherHistory")]
    public IEnumerable<WeatherHistoryRecordDto> Get()
    {
        return dbContext.WeatherHistory.Select(x =>
            new WeatherHistoryRecordDto
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            });
    }

    [HttpPost(Name = "AddWeatherHistoryRecord")]
    public async Task<CreatedResult> Post(WeatherHistoryRecordDto newRecord)
    {
        await dbContext.WeatherHistory.AddAsync(
            new WeatherHistoryRecord
            {
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                TemperatureC = newRecord.TemperatureC,
                Summary = newRecord.Summary
            });
        await dbContext.SaveChangesAsync();

        return Created();
    }
}

public class WeatherHistoryRecordDto
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}