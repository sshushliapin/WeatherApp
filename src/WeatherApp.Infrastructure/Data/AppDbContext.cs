using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain.History;

namespace WeatherApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherHistory");
    }

    public DbSet<HistoryRecord> WeatherHistory { get; set; }
}