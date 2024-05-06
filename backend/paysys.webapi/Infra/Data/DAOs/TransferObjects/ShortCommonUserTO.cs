namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record ShortCommonUserTO
(
    Guid commonUserId,
    string? commonUserName,
    string? commonUserEmail
);
