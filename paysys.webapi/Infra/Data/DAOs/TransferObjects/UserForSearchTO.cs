namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record UserForSearchTO
(
    Guid userId,
    string userName,
    string userTypeName,
    string commonUserName = "",
    string shopkeeperFancyName = ""
);
