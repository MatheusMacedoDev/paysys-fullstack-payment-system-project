using Dapper;
using Npgsql;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class TransferDAO : ITransferDAO
{
    public string? ConnectionString { private get; init; }

    public TransferDAO()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = configuration.GetConnectionString("LocalConnection");
    }

    public TransferDAO(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<IEnumerable<UserTransferHistoryItemTO>> GetUserTransferHistory(Guid userId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT
                        transfers.transfer_id AS transferId,
                        transfers.transfer_description AS transferDescription,
                        categories.transfer_category_name AS transferCategoryName,
                        transfers.transfer_datetime AS transferDateTime,
                        transfers.transfer_amount AS transferAmount,
                        (transfers.sender_user_id = @userId) AS isSenderTransferUser
                    FROM transfers
                    JOIN transfer_categories as categories
                        ON categories.transfer_category_id = transfers.transfer_category_id
                    WHERE transfers.sender_user_id = @userId
                        OR transfers.receiver_user_id = @userId
                    ORDER BY transfers.transfer_datetime
                ";

                return await connection.QueryAsync<UserTransferHistoryItemTO>(query, new { userId });
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FullTransferTO> GetFullTransfer(Guid transferId, Guid userId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT
                        CASE
                            WHEN transfers.sender_user_id = @userId
                                THEN COALESCE(
                                    common_users.common_user_name, 
                                    shopkeepers.fancy_name
                                )
                            WHEN transfers.receiver_user_id = @userId
                                THEN common_users.common_user_name
                            ELSE 'There is no another user'
                        END anotherUserIntoTransferName,
                        transfers.transfer_description AS fullTransferDescription,
                        transfers.transfer_datetime AS transferDateTime,
                        transfers.transfer_amount AS transferAmount,
                        status.transfer_status_name AS transferStatus,
                        categories.transfer_category_name AS transferCategory
                    FROM transfers
                    LEFT JOIN transfer_status AS status
                        ON transfers.transfer_status_id = status.transfer_status_id
                    LEFT JOIN transfer_categories as categories
                        ON transfers.transfer_category_id = categories.transfer_category_id
                    LEFT JOIN common_users
                        ON common_users.user_id = @userId
                    LEFT JOIN shopkeepers
                        ON shopkeepers.user_id = @userId
                ";

                return (await connection.QueryFirstOrDefaultAsync<FullTransferTO>(query, new { transferId, userId }))!;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
