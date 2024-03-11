namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record UserForLoginTO
(
    string userName,
    byte[] userHash,
    byte[] userSalt,
    string userTypeName
);
