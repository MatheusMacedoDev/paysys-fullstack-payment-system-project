namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record ShortShopkeeperTO
(
    Guid shopkeeperId,
    string shopkeeperFancyName,
    string shopkeeperEmail
);
