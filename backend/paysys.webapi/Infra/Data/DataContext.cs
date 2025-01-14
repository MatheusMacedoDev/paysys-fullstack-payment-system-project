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
        seedTransferCategoryData(modelBuilder);
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
            var passwordSalt = new byte[] { 220, 94, 212, 255, 55, 103, 101, 178, 34, 111, 184, 195, 232, 110, 5, 22 };
            var passwordHash = new byte[] { 170, 88, 154, 122, 54, 152, 158, 118, 158, 154, 197, 61, 246, 108, 72, 60, 147, 232, 130, 253, 231, 194, 27, 66, 162, 185, 117, 175, 80, 1, 127, 174 };

            var administratorUser = new User(
                userId: new Guid("3c56843f-fd7a-41bd-8e14-a6b4832fa6fb"),
                userTypeId: _administratorUserTypeId,
                currentDateTime: new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4826)
            );

            var shopkeeperUser = new User(
                userId: new Guid("46121131-1507-4470-83ea-dd0439c51b4c"),
                userTypeId: _shopkeeperUserTypeId,
                currentDateTime: new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4837)
            );

            var commonUser = new User(
                userId: new Guid("8499d00f-fac1-4296-9b2c-d2143cbf1563"),
                userTypeId: _commonUserTypeId,
                currentDateTime: new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4845)
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

    protected void seedTransferCategoryData(ModelBuilder modelBuilder)
    {
        var foodCategoryId = new Guid("9bba9f3e-234f-4ec5-aac3-d2e99f46a59a");
        var transportationCategoryId = new Guid("2e6c6eaf-5d25-4241-b1b0-7d3433824861");
        var hotelsCategoryId = new Guid("384b4ec9-f5ac-406e-b2a2-52733dcc73de");
        var techCategoryId = new Guid("bc7e2062-9aad-4e59-afdb-52733ac514e4");

        modelBuilder.Entity<TransferCategory>(type =>
        {
            type.HasData(
                [
                    new TransferCategory(foodCategoryId),
                    new TransferCategory(transportationCategoryId),
                    new TransferCategory(hotelsCategoryId),
                    new TransferCategory(techCategoryId)
                ]
            );

            type.OwnsOne(c => c.TransferCategoryName)
                .HasData([
                    new { TransferCategoryId = foodCategoryId, NameText = "Alimentação" },
                    new { TransferCategoryId = transportationCategoryId, NameText = "Transporte" },
                    new { TransferCategoryId = hotelsCategoryId, NameText = "Hotelaria" },
                    new { TransferCategoryId = techCategoryId, NameText = "Tecnologia" }
                ]
            );
        });
    }
}
