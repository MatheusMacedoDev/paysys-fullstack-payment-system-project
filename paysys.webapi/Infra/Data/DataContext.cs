using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Infra.Data;

public class DataContext : DbContext
{
    public DbSet<UserType>? UserTypes { get; private set; }
    public DbSet<User>? Users { get; private set; }
    public DbSet<AdministratorUser>? AdministratorUsers { get; private set; }
    public DbSet<CommonUser>? CommonUsers { get; private set; }
    public DbSet<Shopkeeper>? Shopkeepers { get; private set; }

    private string? _connectionString;

    public DataContext(string connectionString = "")
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_connectionString == "")
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("LocalConnection");
        }

        // Postgres Config
        optionsBuilder.UseNpgsql(_connectionString);

        // ORM Config
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
