using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using paysys.webapi.Application.Strategies.Cryptography;
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

    private Guid _administratorUserTypeId = Guid.Parse("0eb973a0-8788-44ca-816b-2ed7dd2ea7e4");
    private Guid _shopkeeperUserTypeId = Guid.Parse("b3a1ff2a-a9e4-4024-8ef7-410da9ea8433");
    private Guid _commonUserTypeId = Guid.Parse("349293cd-cbf6-45ce-a8a5-593a32519d46");

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

        applyModelConfiguration(modelBuilder);
        seedAllData(modelBuilder);
    }

    protected void applyModelConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdministratorUserConfiguration());
        modelBuilder.ApplyConfiguration(new CommonUserConfiguration());
        modelBuilder.ApplyConfiguration(new ShopkeeperConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());
        modelBuilder.ApplyConfiguration(new TransferCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new TransferStatusConfiguration());
        modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
    }

    protected void seedAllData(ModelBuilder modelBuilder)
    {
        seedUserTypeData(modelBuilder);
        seedUserData(modelBuilder);
    }

    protected void seedUserTypeData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserType>(type =>
        {
            type.HasData(
                [
                    new UserType(_administratorUserTypeId),
                    new UserType(_shopkeeperUserTypeId),
                    new UserType(_commonUserTypeId)
                ]
            );

            type.OwnsOne(t => t.TypeName)
                .HasData([
                    new { UserTypeId = _administratorUserTypeId, NameText = "Administrador" },
                    new { UserTypeId = _shopkeeperUserTypeId, NameText = "Lojista" },
                    new { UserTypeId = _commonUserTypeId, NameText = "Comum" }
                ]
            );
        });
    }

    protected void seedUserData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(type =>
        {
            var cryptographyStrategy = new CryptographyStrategy();
            var passwordSalt = cryptographyStrategy.MakeSalt();
            var passwordHash = cryptographyStrategy.MakeHashedPassword("Senha@1234", passwordSalt);

            var administratorUser = new User(
                userTypeId: _administratorUserTypeId
            );

            var shopkeeperUser = new User(
                userTypeId: _shopkeeperUserTypeId
            );

            var commonUser = new User(
                userTypeId: _commonUserTypeId
            );

            type.HasData(
                [
                    administratorUser,
                    shopkeeperUser,
                    commonUser
                ]
            );

            type.OwnsOne(t => t.UserName)
                .HasData([
                    new { UserId = administratorUser.UserId, NameText = "Augusto Diego Elias" },
                    new { UserId = shopkeeperUser.UserId, NameText = "Ian Elias Murilo Oliveira" },
                    new { UserId = commonUser.UserId, NameText = "Gabriela Amanda Melo" }
                ]
            );

            type.OwnsOne(t => t.Email)
                .HasData([
                    new { UserId = administratorUser.UserId, EmailText = "augusto.diego@paysys.com" },
                    new { UserId = shopkeeperUser.UserId, EmailText = "ian.elias@novonegocio.com" },
                    new { UserId = commonUser.UserId, EmailText = "gabriela.amanda@gmail.com" }
                ]
            );

            type.OwnsOne(t => t.PhoneNumber)
                .HasData([
                    new { UserId = administratorUser.UserId, PhoneNumberText = "65996283505" },
                    new { UserId = shopkeeperUser.UserId, PhoneNumberText = "65996283506" },
                    new { UserId = commonUser.UserId, PhoneNumberText = "65996283507" }
                ]
            );

            type.OwnsOne(t => t.Password)
                .HasData([
                    new { UserId = administratorUser.UserId, Hash = passwordHash, Salt = passwordSalt },
                    new { UserId = shopkeeperUser.UserId, Hash = passwordHash, Salt = passwordSalt },
                    new { UserId = commonUser.UserId, Hash = passwordHash, Salt = passwordSalt }
                ]
            );
        });
    }
}
