using MediatR;
using WeatherApp.Domain.History;

namespace WeatherApp.History;

public class GetHistoryRecordRequest : IRequest<List<GetHistoryRecordResponse>>;

public record GetHistoryRecordResponse(DateOnly Date, int TemperatureC, string? Summary);

public class GetHistoryRecordHandler(IHistoryRepository repository) : IRequestHandler<GetHistoryRecordRequest, List<GetHistoryRecordResponse>>
{
    public async Task<List<GetHistoryRecordResponse>> Handle(GetHistoryRecordRequest request, CancellationToken cancellationToken)
    {
        var result = repository.GetHistoryRecords().Select(x =>
            new GetHistoryRecordResponse(x.Date, x.TemperatureC, x.Summary)).ToList();
        return result;
    }
}
