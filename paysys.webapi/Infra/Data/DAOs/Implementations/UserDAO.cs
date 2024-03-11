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
                        users.salt AS userSalt,
                        types.user_type_name AS userTypeName
                    FROM users
                    JOIN user_types AS types
                        ON types.user_type_id = users.user_type_id
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

    public async Task<IEnumerable<UserForSearchTO>> GetUsersByNameOrUsername(string searchedText)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                searchedText = $"%{searchedText}%";

                string query = @"
                    SELECT
                        users.user_id AS userId,
                        users.user_name AS userName,
                        types.user_type_name AS userTypeName,
                            commons.common_user_name AS commonUserName,
                        shopkeepers.fancy_name AS shopkeeperFancyName
                    FROM users
                    LEFT JOIN common_users AS commons
                        ON commons.user_id = users.user_id
                    LEFT JOIN shopkeepers
                        ON shopkeepers.user_id = users.user_id
                    INNER JOIN user_types AS types
                        ON types.user_type_id = users.user_type_id
                    WHERE types.user_type_name LIKE 'Comum' OR types.user_type_name LIKE 'Lojista'
                        AND users.user_name LIKE @searchedText
                        OR shopkeepers.fancy_name LIKE @searchedText
                        OR commons.common_user_name LIKE @searchedText
                ";

                return await connection.QueryAsync<UserForSearchTO>(query, new { searchedText });
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
