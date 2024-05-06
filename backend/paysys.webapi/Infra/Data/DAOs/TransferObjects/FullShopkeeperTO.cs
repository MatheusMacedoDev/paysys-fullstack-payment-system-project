namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record FullShopkeeperTO
(
    Guid shopkeeperId,
    string shopkeeperUserName,
    string shopkeeperFancyName,
    string shopkeeperCompanyName,
    string shopkeeperCNPJ,
    string shopkeeperEmail,
    string shopkeeperPhoneNumber,
    string userTypeName,
    DateTime createdOn,
    DateTime lastUpdatedOn
);
