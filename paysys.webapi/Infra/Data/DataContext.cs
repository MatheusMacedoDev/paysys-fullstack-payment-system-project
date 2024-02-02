using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data;

public class DataContext : DbContext
{
    public DbSet<UserType>? UserTypes { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsetting.json")
            .Build();

        // Postgres Config
        var connectionString = configuration.GetConnectionString("LocalConnection");
        optionsBuilder.UseNpgsql(connectionString);

        // ORM Config
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
