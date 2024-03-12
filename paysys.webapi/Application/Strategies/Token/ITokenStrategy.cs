using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Application.Strategies.Token;

public interface ITokenStrategy
{
    string GenerateToken(UserForLoginTO user);
}
