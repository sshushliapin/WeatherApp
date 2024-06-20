using Microsoft.EntityFrameworkCore;

namespace WeatherApp.History;

public class WeatherHistoryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherHistory");
    }

    public DbSet<WeatherHistoryRecord> WeatherHistory { get; set; }
}