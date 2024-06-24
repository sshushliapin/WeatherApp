namespace WeatherApp.Domain.Forecast
{
    public class WeatherForecast
    {
        public WeatherForecast(DateOnly date, Temperature temperature)
        {
            if (date < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Date cannot be past.");
            }

            Date = date;
            Temperature = temperature;
        }

        public DateOnly Date { get; }

        public Temperature Temperature { get; }

        public string? Summary { get; set; }
    }
}
