using Npgsql;
using paysys.webapi.Infra.Data;

namespace paysys.tests.Infra.Data.Database;

public class DatabaseTestCase : IDisposable
{
    public DataContext DbContext { get; }

    protected DatabaseTestCase(DatabaseFixture databaseFixture)
    {
        var id = Guid.NewGuid().ToString().Replace("-", "");
        var databaseName = $"paysys_db_{id}";

        using (var tmpConnection = new NpgsqlConnection(databaseFixture.ConnectionString))
        {
            tmpConnection.Open();

            string commandText = $"CREATE DATABASE {databaseName} WITH TEMPLATE {databaseFixture.TemplateDatabaseName}";

            using (var command = new NpgsqlCommand(commandText, tmpConnection))
            {
                command.ExecuteNonQuery();
            }

            var connetionString = databaseFixture.GenerateConnectionString(databaseName);
            DbContext = new DataContext(connetionString);
        }
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
    }
}
