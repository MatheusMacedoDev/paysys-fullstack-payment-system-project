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
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            string sql = @"
                SELECT Commons.CommonUserId, Commons.CommonUserName, Users.Email AS CommonUserEmailFROM
                FROM CommonUsers AS Commons
                INNER JOIN Users ON Commons.UserId = Users.UserId
            ";

            var shortCommonUsers = await connection.QueryAsync<ShortCommonUserTO>(sql);

            return shortCommonUsers;
        }
    }
}
