using MediatR;
using WeatherApp.Database;

namespace WeatherApp.Features.History;

public class GetHistoryRecordRequest : IRequest<List<GetHistoryRecordResponse>>
{
    public DateOnly Date { get; set; }
}

public record GetHistoryRecordResponse(DateOnly Date, int TemperatureC, string? Summary);

public class GetHistoryRecordHandler(AppDbContext dbContext) : IRequestHandler<GetHistoryRecordRequest, List<GetHistoryRecordResponse>>
{
    public async Task<List<GetHistoryRecordResponse>> Handle(GetHistoryRecordRequest request, CancellationToken cancellationToken)
    {
        var result = dbContext.WeatherHistory.Select(x =>
            new GetHistoryRecordResponse(x.Date, x.TemperatureC, x.Summary)).ToList();
        return result;
    }
}
