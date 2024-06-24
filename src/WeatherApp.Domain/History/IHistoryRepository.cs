namespace WeatherApp.Domain.History;

public interface IHistoryRepository
{
    IEnumerable<HistoryRecord> GetHistoryRecords();

    Task AddHistoryRecord(HistoryRecord historyRecord, CancellationToken cancellationToken);
}