namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record FullAdministratorTO
(
    Guid administratorId,
    string administratorRealName,
    string administratorUserName,
    string administratorEmail,
    string administratorPhoneNumber,
    string administratorCPF,
    DateTime createdOn,
    DateTime lastUpdatedOn
);
