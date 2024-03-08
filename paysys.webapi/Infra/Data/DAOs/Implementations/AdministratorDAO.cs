using Dapper;
using Npgsql;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class AdministratorDAO : IAdministratorDAO
{
    public string? ConnectionString { private get; init; }

    public AdministratorDAO()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = configuration.GetConnectionString("LocalConnection");
    }

    public async Task<IEnumerable<ShortAdministratorTO>> GetShortAdministrators()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                var query = @"
                    SELECT
                        administrators.administrator_id AS administratorId,
                        administrators.administrator_name AS administratorName,
                        users.email AS administratorEmail
                    FROM administrator_users AS administrators
                    JOIN users
                        ON users.user_id  = administrators.user_id
                ";

                return await connection.QueryAsync<ShortAdministratorTO>(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> GetAdministratorsQuantity()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                var query = "SELECT COUNT(administrator_id) FROM administrator_users";

                return await connection.QuerySingleAsync<int>(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
