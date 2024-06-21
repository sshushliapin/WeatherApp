using MediatR;
using WeatherApp.Database;

namespace WeatherApp.Features.History;

public class GetHistoryRecordRequest : IRequest<List<GetHistoryRecordResponse>>
{
    public DateOnly Date { get; set; }
}

public class GetHistoryRecordResponse
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}

public class GetHistoryRecordHandler(AppDbContext dbContext) : IRequestHandler<GetHistoryRecordRequest, List<GetHistoryRecordResponse>>
{
    public async Task<List<GetHistoryRecordResponse>> Handle(GetHistoryRecordRequest request, CancellationToken cancellationToken)
    {
        var result = dbContext.WeatherHistory.Select(x =>
            new GetHistoryRecordResponse
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary
            }).ToList();
        return result;
    }
}
