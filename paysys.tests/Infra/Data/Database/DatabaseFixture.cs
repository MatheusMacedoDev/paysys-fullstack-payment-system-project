using Microsoft.EntityFrameworkCore;
using paysys.webapi.Infra.Data;

namespace paysys.tests.Infra.Data.Database;

public class DatabaseFixture : IDisposable
{
    public string? TemplateDatabaseName { get; set; }
    public string? ConnectionString { get; set; }

    private DataContext? _context;

    public DatabaseFixture()
    {
        AddDatabaseNameToConnection("paysys_db");
        ConfigureDatabaseTemplate();
    }

    public void Dispose()
    {
        if (_context != null)
            _context.Database.EnsureDeleted();
    }

    public string GenerateConnectionString(string databaseName)
    {
        return $"Host = localhost; Port = 5433; Database = {databaseName}; User Id = postgres; Password = T0rt4d3l1m40";
    }

    private void AddDatabaseNameToConnection(string databaseName)
    {
        var randomId = Guid.NewGuid().ToString().Replace("-", "");
        TemplateDatabaseName = $"{databaseName}_{randomId}";
        ConnectionString = GenerateConnectionString(TemplateDatabaseName);
    }

    private void ConfigureDatabaseTemplate()
    {
        _context = new DataContext(ConnectionString!);

        _context.Database.EnsureCreated();

        _context.Database.CloseConnection();
    }
}
