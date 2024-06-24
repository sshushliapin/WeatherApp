namespace WeatherApp.Domain.Forecast;

public class Temperature(int temperatureC)
{
    public static int MinC => -20;

    public static int MaxC => 50;

    public override string ToString()
    {
        return $"{temperatureC} C";
    }

    public string ToFahrenheit()
    {
        return $"{32 + (int)(temperatureC / 0.5556)} F";
    }
}