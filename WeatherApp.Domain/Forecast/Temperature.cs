namespace WeatherApp.Domain.Forecast;

public class Temperature(int temperatureC)
{
    public override string ToString()
    {
        return $"{temperatureC} C";
    }

    public string ToFahrenheit()
    {
        return $"{32 + (int)(temperatureC / 0.5556)} F";
    }
}