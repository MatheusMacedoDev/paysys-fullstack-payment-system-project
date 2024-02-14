namespace paysys.webapi.Application.Contracts.Responses;

public record CreateShopkeeperResponse
(
    Guid shopkeeperId,
    Guid userId,
    string fancyName
);
