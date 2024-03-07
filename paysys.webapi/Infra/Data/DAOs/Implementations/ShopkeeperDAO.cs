using Dapper;
using Npgsql;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class ShopkeeperDAO : IShopkeeperDAO
{
    public string? ConnectionString { private get; init; }

    public ShopkeeperDAO()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = configuration.GetConnectionString("LocalConnection");
    }

    public async Task<IEnumerable<ShortShopkeeperTO>> getShortShopkeepers()
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

    public async Task<int> getShopkeepersQuantity()
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
}
