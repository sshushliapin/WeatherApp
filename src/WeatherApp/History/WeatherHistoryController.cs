using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WeatherApp.History;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class WeatherHistoryController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = "GetWeatherHistory")]
    public async Task<IActionResult> Get()
    {
        var request = new GetHistoryRecordRequest();
        var result = await mediator.Send(request);
        return Ok(result);
    }

    [HttpPost(Name = "AddWeatherHistoryRecord")]
    public async Task<IActionResult> Post([Required] CreateHistoryRecordRequest request)
    {
        var result = await mediator.Send(request);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return Created();
    }
}