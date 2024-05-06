namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record ShortAdministratorTO
(
    Guid administratorId,
    string administratorName,
    string administratorEmail
);
