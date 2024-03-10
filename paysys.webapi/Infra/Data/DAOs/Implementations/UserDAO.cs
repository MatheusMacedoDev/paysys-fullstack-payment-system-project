using Dapper;
using Npgsql;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class UserDAO : IUserDAO
{
    public string? ConnectionString { private get; init; }

    public UserDAO()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = configuration.GetConnectionString("LocalConnection");
    }

    public UserDAO(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<UserForLoginTO> GetUserByEmail(string userEmail)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT
                        users.user_name AS userName,
                        users.hash AS userHash,
                        users.salt AS userSalt
                    FROM users
                    WHERE users.email = @email
                ";

                return (await connection.QueryFirstOrDefaultAsync<UserForLoginTO>(query, new { email = userEmail }))!;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
