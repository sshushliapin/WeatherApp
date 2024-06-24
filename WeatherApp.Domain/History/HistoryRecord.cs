namespace WeatherApp.Domain.History;

public class HistoryRecord
{
    public HistoryRecord(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public int Id { get; protected set; }

    public DateOnly Date { get; protected set; }

    public int TemperatureC { get; protected set; }

    public string? Summary { get; protected set; }
}