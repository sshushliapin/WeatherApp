using MediatR;
using WeatherApp.Database;

namespace WeatherApp.Features.History;

public static class GetHistoryRecord
{
    public class GetHistoryRecordRequest : IRequest<List<Response>>
    {
        public DateOnly Date { get; set; }
    }

    public class Response
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }

    public class Handler(AppDbContext dbContext) : IRequestHandler<GetHistoryRecordRequest, List<Response>>
    {
        public async Task<List<Response>> Handle(GetHistoryRecordRequest request, CancellationToken cancellationToken)
        {
            var result = dbContext.WeatherHistory.Select(x =>
                new Response
                {
                    Date = x.Date,
                    TemperatureC = x.TemperatureC,
                    Summary = x.Summary
                }).ToList();
            return result;
        }
    }
}