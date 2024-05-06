namespace paysys.webapi.Application.Contracts.Responses;

public record class CreateAdministratorResponse
(
    Guid administratorId,
    Guid userId,
    string administratorName
);
