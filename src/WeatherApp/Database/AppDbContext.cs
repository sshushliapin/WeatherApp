using Microsoft.EntityFrameworkCore;
using WeatherApp.Entities;

namespace WeatherApp.Database;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherHistory");
    }

    public DbSet<WeatherHistoryRecord> WeatherHistory { get; set; }
}