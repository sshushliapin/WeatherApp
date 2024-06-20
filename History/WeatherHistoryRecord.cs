namespace WeatherApp.History;

public class WeatherHistoryRecord
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}