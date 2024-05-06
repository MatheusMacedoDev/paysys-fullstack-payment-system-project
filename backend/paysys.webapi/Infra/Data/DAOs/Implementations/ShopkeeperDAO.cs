using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using paysys.webapi.Configuration;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class ShopkeeperDAO : IShopkeeperDAO
{
    public string? ConnectionString { private get; init; }

    public ShopkeeperDAO(IOptions<ConnectionStringSettings> settings)
    {
        ConnectionString = settings.Value.LocalConnection;
    }

    public ShopkeeperDAO(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<IEnumerable<ShortShopkeeperTO>> GetShortShopkeepers()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT 
                        shopkeepers.shopkeeper_id AS shopkeeperId,
                        shopkeepers.fancy_name AS shopkeeperFancyName,
                        users.email AS shopkeeperEmail
                    FROM shopkeepers
                    JOIN users
                    ON users.user_id = shopkeepers.user_id
                ";

                return await connection.QueryAsync<ShortShopkeeperTO>(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> GetShopkeepersQuantity()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(shopkeeper_id) FROM shopkeepers";

                return (await connection.QueryAsync<int>(query)).First();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FullShopkeeperTO> GetFullShopkeeperById(Guid shopkeeperId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT
                        shopkeepers.shopkeeper_id AS shopkeeperId,
                        users.user_name AS shopkeeperUserName,
                        shopkeepers.fancy_name AS shopkeeperFancyName,
                        shopkeepers.company_name AS shopkeeperCompanyName,
                        shopkeepers.shopkeeper_cnpj AS shopkeeperCNPJ,
                        users.email AS shopkeeperEmail,
                        users.phone_number AS shopkeeperPhoneNumber,
                        types.user_type_name AS userTypeName,
                        users.created_on AS createdOn,
                        users.last_updated_on AS lastUpdatedOn
                    FROM shopkeepers
                    JOIN users
                        ON users.user_id = shopkeepers.user_id
                    JOIN user_types AS types
                        ON types.user_type_id = users.user_type_id
                    WHERE shopkeepers.shopkeeper_id = @id
                ";

                return (await connection.QueryFirstOrDefaultAsync<FullShopkeeperTO>(query, new { id = shopkeeperId }))!;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<double> GetShopkeeperBalanceByUserId(Guid userId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT balance
                    FROM shopkeepers
                    WHERE user_id = @userId
                ";

                return await connection.QueryFirstOrDefaultAsync<double>(query, new { userId });
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
