using WeatherApp.Domain.History;
using WeatherApp.Infrastructure.Data;

namespace WeatherApp.Infrastructure.History;

public class HistoryRepository(AppDbContext dbContext) : IHistoryRepository
{
    public IEnumerable<HistoryRecord> GetHistoryRecords()
    {
        // Assume always return last 3 records
        return dbContext.WeatherHistory.OrderBy(x => x.Date).Take(3);
    }

    public async Task AddHistoryRecord(HistoryRecord historyRecord, CancellationToken cancellationToken)
    {
        dbContext.Add(historyRecord);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}