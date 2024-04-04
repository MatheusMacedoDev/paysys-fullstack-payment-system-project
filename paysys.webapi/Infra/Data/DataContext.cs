using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Infra.Data.DbConfiguration;

namespace paysys.webapi.Infra.Data;

public class DataContext : DbContext
{
    public DbSet<UserType>? UserTypes { get; private set; }
    public DbSet<User>? Users { get; private set; }
    public DbSet<AdministratorUser>? AdministratorUsers { get; private set; }
    public DbSet<CommonUser>? CommonUsers { get; private set; }
    public DbSet<Shopkeeper>? Shopkeepers { get; private set; }
    public DbSet<Transfer>? Transfers { get; private set; }
    public DbSet<TransferStatus>? TransferStatus { get; private set; }
    public DbSet<TransferCategory>? TransferCategories { get; private set; }

    private string? _connectionString;

    public DataContext(IOptions<ConnectionStringSettings> settings)
    {
        _connectionString = settings.Value.LocalConnection;
    }

    public DataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Postgres Config
        optionsBuilder.UseNpgsql(_connectionString);

        // ORM Config
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<Notification>();

        modelBuilder.ApplyConfiguration(new AdministratorUserConfiguration());
        modelBuilder.ApplyConfiguration(new CommonUserConfiguration());
        modelBuilder.ApplyConfiguration(new ShopkeeperConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());
    }
}
