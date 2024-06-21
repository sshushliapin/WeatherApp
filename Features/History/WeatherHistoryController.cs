using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WeatherApp.Features.History;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class WeatherHistoryController(WeatherHistoryDbContext dbContext) : ControllerBase
{
    [HttpGet(Name = "GetWeatherHistory")]
    public IEnumerable<HistoryRecordResponse> Get()
    {
        return dbContext.WeatherHistory.Select(x =>
            new HistoryRecordResponse
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            });
    }

    [HttpPost(Name = "AddWeatherHistoryRecord")]
    public async Task<CreatedResult> Post(CreateHistoryRecordRequest newRecord)
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
public class HistoryRecordResponse
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}

public class CreateHistoryRecordRequest
{
    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}