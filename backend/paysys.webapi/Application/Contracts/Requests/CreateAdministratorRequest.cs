namespace paysys.webapi.Application.Contracts.Requests;

public record CreateAdministratorRequest(
    string administratorName,
    string cpf,
    string userName,
    string email,
    string phoneNumber,
    string password,
    Guid userTypeId
);
