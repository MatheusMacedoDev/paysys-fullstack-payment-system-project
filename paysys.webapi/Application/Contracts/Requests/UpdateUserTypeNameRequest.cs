namespace paysys.webapi.Application.Contracts.Requests;

public record UpdateUserTypeNameRequest(
    Guid userTypeId,
    string newTypeName
);
