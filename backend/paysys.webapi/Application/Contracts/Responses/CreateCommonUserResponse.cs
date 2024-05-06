namespace paysys.webapi.Application.Contracts.Responses;

public record CreateCommonUserResponse
(
    Guid commonUserId,
    Guid userId,
    string commonUserName
);
