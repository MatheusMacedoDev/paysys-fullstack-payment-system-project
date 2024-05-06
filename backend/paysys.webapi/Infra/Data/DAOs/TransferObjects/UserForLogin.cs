namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record UserForLoginTO
(
    Guid userId,
    string userName,
    byte[] userHash,
    byte[] userSalt,
    string userTypeName
);
