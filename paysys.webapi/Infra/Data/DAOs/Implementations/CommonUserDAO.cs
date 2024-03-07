using Dapper;
using Npgsql;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class CommonUserDAO : ICommonUserDAO
{
    public string? ConnectionString { private get; init; }

    public CommonUserDAO()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = configuration.GetConnectionString("LocalConnection");
    }

    public async Task<IEnumerable<ShortCommonUserTO>> getShortCommonUsers()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT 
                        commons.common_user_id AS commonUserId, 
                        users.user_name AS commonUserName, 
                        users.email AS commonUserEmail 
                    FROM public.common_users AS commons
                    JOIN public.users AS users 
                    ON users.user_id = commons.user_id
                ";

                return await connection.QueryAsync<ShortCommonUserTO>(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> getCommonUsersQuantity()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(common_user_id) FROM common_users";

                return (await connection.QueryAsync<int>(query)).First();
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
