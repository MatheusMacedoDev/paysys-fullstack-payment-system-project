namespace paysys.webapi.Application.Contracts.Requests;

public record CreateCommonUserRequest
(
    string commonUserName,
    string cpf,
    string userName,
    string email,
    string phoneNumber,
    string password,
    Guid userTypeId
);
