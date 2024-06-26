﻿using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using paysys.webapi.Configuration;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Implementation;

public class CommonUserDAO : ICommonUserDAO
{
    public string? ConnectionString { private get; init; }

    public CommonUserDAO(IOptions<ConnectionStringSettings> settings)
    {
        ConnectionString = settings.Value.LocalConnection;
    }

    public CommonUserDAO(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<IEnumerable<ShortCommonUserTO>> GetShortCommonUsers()
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
                    FROM common_users AS commons
                    JOIN users 
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

    public async Task<int> GetCommonUsersQuantity()
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(common_user_id) FROM common_users";

                return (await connection.QueryAsync<int>(query)).First();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FullCommonUserTO> GetFullCommonUserById(Guid commonUserId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT 
                        commons.common_user_id AS commonUserId,
                        commons.common_user_name AS commonUserRealName,
                        users.user_name AS commonUserName,
                        users.email AS commonUserEmail,
                        users.phone_number AS commonUserPhoneNumber,
                        commons.common_user_cpf AS commonUserCPF,
                        types.user_type_name AS userTypeName,
                        users.created_on AS createdOn,
                        users.last_updated_on AS lastUpdatedOn
                    FROM common_users AS commons
                    JOIN users
                        ON users.user_id = commons.user_id
                    JOIN user_types AS types
                        ON types.user_type_id = users.user_type_id
                    WHERE commons.common_user_id = @id
                ";

                return (await connection.QueryFirstOrDefaultAsync<FullCommonUserTO>(query, new { id = commonUserId }))!;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<double> GetCommonUserBalance(Guid commonUserId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT balance
                    FROM common_users
                    WHERE common_user_id = @commonUserId
                ";

                return await connection.QueryFirstOrDefaultAsync<double>(query, new { commonUserId });
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<double> GetCommonUserBalanceByUserId(Guid userId)
    {
        try
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string query = @"
                    SELECT balance
                    FROM common_users
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
