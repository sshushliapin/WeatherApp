using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WeatherApp.Features.History;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class WeatherHistoryController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = "GetWeatherHistory")]
    public async Task<IActionResult> Get(GetHistoryRecord.GetHistoryRecordRequest? request)
    {
        request ??= new GetHistoryRecord.GetHistoryRecordRequest();
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpPost(Name = "AddWeatherHistoryRecord")]
    public async Task<IActionResult> Post(CreateHistoryRecord.CreateHistoryRecordRequest request)
    {
        var result = await mediator.Send(request);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return Created();
    }
}