namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record FullCommonUserTO
(
    Guid commonUserId,
    string? commonUserRealName,
    string? commonUsername,
    string? commonUserEmail,
    string? commonUserPhoneNumber,
    string? userTypeName,
    DateTime createdOn,
    DateTime lastUpdatedOn
);
