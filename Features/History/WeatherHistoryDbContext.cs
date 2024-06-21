using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Features.History;

public class WeatherHistoryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherHistory");
    }

    public DbSet<WeatherHistoryRecord> WeatherHistory { get; set; }
}