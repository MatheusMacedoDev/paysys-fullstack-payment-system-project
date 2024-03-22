namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public record FullTransferTO(
    string anotherUserIntoTransferName,
    string fullTransferDescription,
    DateTime transferDateTime,
    decimal transferAmount,
    string transferStatus,
    string transferCategory
);
